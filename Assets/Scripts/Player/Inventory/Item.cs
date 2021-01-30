using UnityEngine;

/// <summary>
/// Interactive object in the world
/// </summary>
public class Item : MonoBehaviour
{
    public ItemType type;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var inventory = other.gameObject.GetComponent<Inventory>();

        if (inventory is null)
            return;

        if (inventory.AddItem(this))
        {
            Destroy(this.gameObject);
        }
    }
}
