using UnityEngine;

public class Gate : MonoBehaviour, IInteractive
{
    public GameObject smokeEffect;

    public void Interact(Tana caller)
    {
        var inventory = caller.GetComponent<Inventory>();

        var count = inventory.GetItemCountByType(ItemType.KEY);

        if (count == 2)
        {
            caller.PushDialog(new string[] { "Puerta abierta." });
            Destroy(this.gameObject);
            Instantiate(this.smokeEffect, this.transform.position, Quaternion.identity);
        }
        else
        {
            caller.PushDialog(new string[] { "Hay dos huecos para dos llaves" });
        }
    }
}