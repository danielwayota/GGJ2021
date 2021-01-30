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
        this.dialogTextLabel.gameObject.SetActive(true);
        this.dialogTextLabel.text = line;
    }

    public void Hide()
    {
        this.dialogTextLabel.gameObject.SetActive(false);
    }
}