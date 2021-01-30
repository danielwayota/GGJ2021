using UnityEngine;

public class RespawnPoint : ActivationSender
{
    protected override bool isValid => true;

    public override void Restore()
    {
        this.isActivated = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        this.isActivated = true;
    }
}