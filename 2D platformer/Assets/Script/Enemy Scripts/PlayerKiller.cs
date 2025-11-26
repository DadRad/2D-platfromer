using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            EventManager.Instance.PlayerKill();
        }
    }
}
