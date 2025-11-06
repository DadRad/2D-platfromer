using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int _coinsToWin = 5;
    private int _coinsCollected;

     public event System.Action OnAllCoinsCollected;

    public event System.Action<GameObject> OnCoinCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            OnCoinCollected?.Invoke(collision.gameObject);
            _coinsCollected++;

            if (_coinsCollected >= _coinsToWin)
            {
                OnAllCoinsCollected?.Invoke();
            }
        }
    }
}

