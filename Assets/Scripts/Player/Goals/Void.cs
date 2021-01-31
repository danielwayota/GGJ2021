using System.Collections;
using UnityEngine;

public class Void : MonoBehaviour, IInteractive
{
    public GameObject finalShine;

    public AudioSource finalSound;

    public SpriteRenderer head;
    public SpriteRenderer body;

    private void Start() {
        StartCoroutine(this.CheckFragments());
    }

    public void Interact(Tana caller)
    {
        var inventory = caller.GetComponent<Inventory>();

        var count = inventory.GetItemCountByType(ItemType.SELF_FRAGMENT);

        if (count == 2)
        {
            Instantiate(this.finalShine, this.transform.position, Quaternion.identity);

            this.finalSound.Play();

            caller.PushDialog(new string[] {
                "¡Felicidades! Hasta aquí llega este minijuego",
                "Gracias por jugar :D"
            });
        }
        else
        {
            caller.PushDialog(new string[] { "El vacío te devuelve la mirada." });
        }
    }

    IEnumerator CheckFragments()
    {
        Inventory inventory = null;

        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (inventory is null)
            {
                inventory = GameObject.FindObjectOfType<Inventory>();
            }
            else
            {
                var count = inventory.GetItemCountByType(ItemType.SELF_FRAGMENT);

                switch (count)
                {
                    case 0:
                        this.head.color = Color.black;
                        this.body.color = Color.black;
                        break;
                    case 1:
                        this.head.color = Color.black;
                        this.body.color = Color.white;
                        break;
                    case 2:
                        this.head.color = Color.white;
                        this.body.color = Color.white;
                        break;
                }
            }
        }
    }
}