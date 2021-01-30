using UnityEngine;
using UnityEngine.UI;

public class ItemBagUI : MonoBehaviour
{
    public Image[] icons;

    public Color voidColor = Color.black;
    public Color haveColor = Color.white;

    void Start()
    {
        this.SetItems(0);
    }

    public void SetItems(int count)
    {
        foreach (var icon in this.icons)
        {
            icon.color = this.voidColor;
        }

        for (int i = 0; i < count; i++)
        {
            this.icons[i].color = this.haveColor;
        }
    }
}
