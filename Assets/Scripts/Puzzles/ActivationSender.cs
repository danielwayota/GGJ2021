using UnityEngine;

public abstract class ActivationSender : MonoBehaviour
{
    public Sprite inactive;
    public Sprite active;

    protected abstract bool isValid
    {
        get;
    }

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

                this.receiver.Activate(this.isValid, this);
            }
            else
            {
                this.gfx.sprite = this.inactive;
            }
        }
    }

    private SpriteRenderer _gfx;
    private SpriteRenderer gfx
    {
        get {
            if (this._gfx is null)
            {
                this._gfx = this.GetComponentInChildren<SpriteRenderer>();
            }

            return this._gfx;
        }
    }

    public ActivationReceiver receiver;

    public abstract void Restore();
}