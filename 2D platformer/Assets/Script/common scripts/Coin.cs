using UnityEngine;

public class Coin : MonoBehaviour
{   
    [SerializeField] private LayerMask _playerLayer;

    private bool isCollected = false;

    public event System.Action<Coin> CoinCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (1 << collision.gameObject.layer == _playerLayer)
        {
            isCollected = true;
            gameObject.SetActive(false);
            CoinCollected?.Invoke(this);
        }
    }
}
