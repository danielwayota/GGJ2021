using UnityEngine;

public class GameManager : ActivationReceiver
{
    public static GameManager current;

    private Vector3 resetPosition;
    private ActivationSender lastRespawnPoint;

    void Awake()
    {
        current = this;
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
}
