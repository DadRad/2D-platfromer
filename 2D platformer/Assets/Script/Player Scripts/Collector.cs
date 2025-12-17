using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    [SerializeField] private LayerMask _coinLayer;
    [SerializeField] private LayerMask _medkitLayer;
    private int _coinsToWin = 5;
    private int _coinsCollected;

    public event System.Action OnAllCoinsCollected;
    public event System.Action<GameObject> OnCoinCollected;
    public event System.Action MedkitCollected;

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
        else if (((1 << collision.gameObject.layer) & _medkitLayer) != 0)
        {
            MedkitCollected?.Invoke();
            Destroy(collision.gameObject);
        }
    }
}
