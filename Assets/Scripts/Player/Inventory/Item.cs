using UnityEngine;

/// <summary>
/// Interactive object in the world
/// </summary>
public class Item : MonoBehaviour
{
    public ItemType type;

    public AudioClip pickSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var inventory = other.gameObject.GetComponent<Inventory>();

        if (inventory is null)
            return;

        if (inventory.AddItem(this))
        {
            Destroy(this.gameObject);
        }

        if (this.pickSound != null)
            AudioSource.PlayClipAtPoint(this.pickSound, this.transform.position, 1.5f);
    }
}
