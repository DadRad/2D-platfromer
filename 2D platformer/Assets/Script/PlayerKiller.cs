using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            GlobalEvents.PlayerKilled();
        }
    }
}
