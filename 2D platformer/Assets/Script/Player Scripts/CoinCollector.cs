using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private LayerMask _coinLayer;

    private int _coinsToWin = 5;

    public event System.Action OnAllCoinsCollected;
    public event System.Action<GameObject> OnCoinCollected;

    private int _coinsCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _coinLayer) != 0)
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
