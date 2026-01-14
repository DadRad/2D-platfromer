using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private LayerMask _coinLayer;
    [SerializeField] private LayerMask _medkitLayer;
    private int _coinsToWin = 5;
    private int _coinsCollected;

    public event System.Action AllCoinsCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & _coinLayer) != 0)
        {
            _coinsCollected++;

            Debug.Log("Монет собрано " + _coinsCollected);

            if (_coinsCollected >= _coinsToWin)
            {
                AllCoinsCollected?.Invoke();
            }
        }
    }
}
