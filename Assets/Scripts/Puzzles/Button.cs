using UnityEngine;

public class Button : ActivationSender
{
    public Sprite inactive;
    public Sprite active;

    public ActivationReceiver receiver;
    public bool isAValidButton;

    private SpriteRenderer gfx;

    private bool _isActivated;
    public bool isActivated
    {
        get => this._isActivated;
        set
        {
            this._isActivated = value;

            if (this._isActivated)
            {
                this.gfx.sprite = this.active;

                this.receiver.Activate(this.isAValidButton);
            }
            else
            {
                this.gfx.sprite = this.inactive;
            }
        }
    }

    void Start()
    {
        this.gfx = this.GetComponentInChildren<SpriteRenderer>();
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
