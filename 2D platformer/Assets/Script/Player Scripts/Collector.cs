using NUnit.Framework;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private int _coinsToWin = 5;
    private int _coinsCollected;

    public event System.Action AllCoinsCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            if(coin.IsCollected) return;

            coin.Collect();
            _coinsCollected++;
            Debug.Log($"Монет подобрано: {_coinsCollected}");

            if (_coinsCollected >= _coinsToWin)
            {
                AllCoinsCollected?.Invoke();
            }
        }

        if (collision.TryGetComponent<Medkit>(out Medkit medkit))
        {
            if (medkit.IsCollected) return;

            medkit.RestoreHealth();
            medkit.gameObject.SetActive(false);
        }
    }
}
