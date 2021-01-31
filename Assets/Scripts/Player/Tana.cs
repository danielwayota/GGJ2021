using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main player character
/// </summary>
public class Tana : MonoBehaviour
{
    public float speed = 2f;

    [Header("Interaction")]
    public LayerMask whatIsInteractuable;
    public float interactRadius;

    private Rigidbody2D body;

    private Queue<string> dialogLines;
    private bool hasDialog;

    public DialogUI dialogUI;

    void Start()
    {
        this.body = this.GetComponent<Rigidbody2D>();
        this.hasDialog = false;

        this.dialogLines = new Queue<string>();
    }

    void Update()
    {
        var mov = Vector2.zero;

        if (this.hasDialog)
        {
            if (Input.GetButtonDown("Jump"))
            {
                this.ShowNextDialogLine();
            }
        }
        else
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            mov = (new Vector2(h, v)).normalized;

            if (Input.GetButtonDown("Jump"))
            {
                var hit = Physics2D.OverlapCircle(this.transform.position, this.interactRadius, this.whatIsInteractuable);
                if (hit != null)
                {
                    var interactive = hit.gameObject.GetComponent<IInteractive>();
                    interactive.Interact(this);
                }
            }
        }

        this.body.velocity = mov * this.speed;
    }

    public void Respawn(Vector3 location)
    {
        this.gameObject.SetActive(true);
        this.transform.position = location;
    }

    public void Die()
    {
        this.gameObject.SetActive(false);

        GameManager.current.Death();
    }

    public void PushDialog(string[] lines)
    {
        foreach (var l in lines)
        {
            this.dialogLines.Enqueue(l);
        }

        this.ShowNextDialogLine();
    }

    public void ShowNextDialogLine()
    {
        if (this.dialogLines.Count > 0)
        {
            var line = this.dialogLines.Dequeue();
            this.dialogUI.Show(line);

            this.hasDialog = true;
        }
        else
        {
            this.hasDialog = false;
            this.dialogUI.Hide();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(this.transform.position, this.interactRadius);
    }
}
