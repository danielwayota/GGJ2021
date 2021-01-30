using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxItems = 2;

    private int selfFragmentCount = 0;
    private int keyCount = 0;

    public ItemBagUI selfFragmentsUI;
    public ItemBagUI keysUI;

    public bool AddItem(Item item)
    {
        switch (item.type)
        {
            case ItemType.SELF_FRAGMENT:
                if (this.selfFragmentCount == this.maxItems) return false;

                this.selfFragmentCount++;
                this.selfFragmentsUI.SetItems(this.selfFragmentCount);

                break;
            case ItemType.KEY:
                if (this.keyCount == this.maxItems) return false;

                this.keyCount++;
                this.keysUI.SetItems(this.keyCount);

                break;
        }

        return true;
    }

    public bool RemoveItemByType(ItemType type, int count = 1)
    {
        switch (type)
        {
            case ItemType.SELF_FRAGMENT:
                if (this.selfFragmentCount > 0)
                {
                    this.selfFragmentCount -= count;
                    this.selfFragmentsUI.SetItems(this.selfFragmentCount);
                    return true;
                }
                break;
            case ItemType.KEY:
                if (this.keyCount > 0)
                {
                    this.keyCount -= count;
                    this.keysUI.SetItems(this.keyCount);
                    return true;
                }
                break;
        }

        return false;
    }

    public int GetItemCountByType(ItemType type)
    {
        switch (type)
        {
            case ItemType.SELF_FRAGMENT:
                return this.selfFragmentCount;
            case ItemType.KEY:
                return this.keyCount;
        }

        return 0;
    }
}