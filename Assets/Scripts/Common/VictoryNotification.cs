using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VictoryNotification : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _victoryText;
    [SerializeField] private Collector _coinCollector;

    private int _coinsToWin = 5;
    private int _coinsCollected;

    private void OnEnable()
    {
        _coinCollector.CoinCollected += UpdateCoinsCount;
    }

    private void OnDisable()
    {
        _coinCollector.CoinCollected -= UpdateCoinsCount;
    }

    private void UpdateCoinsCount()
    {
        _coinsCollected++;

        if (_coinsCollected >= _coinsToWin)
        {
            ShowVictory();
        }
    }
    
    private void ShowVictory()
    {
        _victoryText.gameObject.SetActive(true);
    }
}
