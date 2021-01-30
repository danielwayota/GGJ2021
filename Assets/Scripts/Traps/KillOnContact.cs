using UnityEngine;

public class KillOnContact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        var tana = other.GetComponent<Tana>();

        if (tana != null)
            tana.Die();
    }
}