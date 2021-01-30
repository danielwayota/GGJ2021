using UnityEngine;

public class DoorWithKey : MonoBehaviour, IInteractive
{
    public void Interact(Tana caller)
    {
        var invetory = caller.GetComponent<Inventory>();
        if (invetory is null)
            return;

        var keyCount = invetory.GetItemCountByType(ItemType.KEY);

        if (keyCount == 0)
        {
            caller.PushDialog(new string[] {"Hay dos huecos para dos llaves"});
        }
        else if (keyCount == 1)
        {
            caller.PushDialog(new string[] {"Hay un hueco para una llave"});
        }
        else
        {
            caller.PushDialog(new string[] {"Se abre"});
            invetory.RemoveItemByType(ItemType.KEY, 2);
        }
    }
}
