using UnityEngine;

public class Dialoguer : MonoBehaviour, IInteractive
{
    public string[] lines;

    public void Interact(Tana caller)
    {
        caller.PushDialog(this.lines);
    }
}
