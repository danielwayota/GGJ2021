using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tana : MonoBehaviour
{
    public float speed = 2f;

    private Rigidbody2D body;

    void Start()
    {
        this.body = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        var mov = (new Vector2(h, v)).normalized;

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
}
