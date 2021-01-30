using UnityEngine;

public class GameManager : ActivationReceiver
{
    public static GameManager current;

    private Vector3 resetPosition;
    private ActivationSender lastRespawnPoint;

    private Tana player;

    void Awake()
    {
        current = this;

        this.player = GameObject.FindObjectOfType<Tana>();
        this.resetPosition = this.player.transform.position;
    }

    public override void Activate(bool isValid, ActivationSender sender)
    {
        if (this.lastRespawnPoint != null)
        {
            this.lastRespawnPoint.Restore();
        }

        this.resetPosition = sender.transform.position;

        this.lastRespawnPoint = sender;
    }

    // Ignored
    public override void AddSender(ActivationSender sender) { }
    public override void OnSolvedChanged() {}

    public void Death()
    {
        Invoke("Respawn", 1f);
    }

    public void Respawn()
    {
        this.player.Respawn(this.resetPosition);
    }
}
