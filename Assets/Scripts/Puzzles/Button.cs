using UnityEngine;

public class Button : ActivationSender
{
    public bool isAValidButton;

    protected override bool isValid => this.isAValidButton;

    void Start()
    {
        this.isActivated = false;

        if (this.receiver != null)
        {
            this.receiver.AddSender(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        this.isActivated = true;
    }

    private void OnDrawGizmos()
    {
        if (this.receiver is null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position,0.5f);
        }
        else
        {
            if (this.isAValidButton)
                Gizmos.color = Color.green;
            else
                Gizmos.color = Color.magenta;


            Gizmos.DrawLine(this.transform.position, this.receiver.transform.position);
            Gizmos.DrawWireSphere(this.transform.position, 0.5f);
            Gizmos.DrawWireSphere(this.receiver.transform.position, 0.5f);
        }
    }

    public override void Restore()
    {
        this.isActivated = false;
    }
}
