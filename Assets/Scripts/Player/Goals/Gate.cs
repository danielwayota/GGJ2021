using UnityEngine;

public class Gate : MonoBehaviour, IInteractive
{
    public void Interact(Tana caller)
    {
        var inventory = caller.GetComponent<Inventory>();

        var count = inventory.GetItemCountByType(ItemType.KEY);

        if (count == 2)
        {
            caller.PushDialog(new string[] { "ABRIR" });
            Destroy(this.gameObject);
        }
        else
        {
            caller.PushDialog(new string[] { "Hay dos huecos para dos llaves" });
        }
    }
}