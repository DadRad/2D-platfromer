using UnityEngine;

public class VictoryNotification : MonoBehaviour
{
    [SerializeField] private GameObject _victoryText;
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
        _victoryText.SetActive(true);
    }
}
