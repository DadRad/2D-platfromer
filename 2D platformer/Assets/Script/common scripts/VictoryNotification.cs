using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VictoryNotification : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _victoryText;
    [SerializeField] private CoinCollector _coinCollector;

    private void OnEnable()
    {

        _coinCollector.OnAllCoinsCollected += ShowVictory;
    }

    private void OnDisable()
    {
        _coinCollector.OnAllCoinsCollected -= ShowVictory;
    }
    
    private void ShowVictory()
    {
        _victoryText.gameObject.SetActive(true);
    }
}
