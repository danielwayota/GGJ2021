using UnityEngine;

public class Void : MonoBehaviour, IInteractive
{
    public void Interact(Tana caller)
    {
        var inventory = caller.GetComponent<Inventory>();

        var count = inventory.GetItemCountByType(ItemType.SELF_FRAGMENT);

        if (count == 2)
        {
            caller.PushDialog(new string[] { "FIN" });
        }
        else
        {
            caller.PushDialog(new string[] { "El vacío te devuelve la mirada." });
        }
    }
}