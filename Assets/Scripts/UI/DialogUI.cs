using UnityEngine;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour
{
    public Text dialogTextLabel;

    void Start()
    {
        this.Hide();
    }

    public void Show(string line)
    {
        this.gameObject.SetActive(true);
        this.dialogTextLabel.text = line;
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}