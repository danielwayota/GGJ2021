using UnityEngine;

public abstract class ActivationReceiver : MonoBehaviour
{
    private bool _solved;
    protected bool solved
    {
        get => this._solved;
        set {
            this._solved = value;

            this.OnSolvedChanged();
        }
    }

    public abstract void OnSolvedChanged();
    public abstract void AddSender(ActivationSender sender);
    public abstract void Activate(bool isValid);
}
