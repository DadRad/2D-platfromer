using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VictoryNotification : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _victoryText;
    [SerializeField] private Collector _coinCollector;

    private void OnEnable()
    {

        _coinCollector.AllCoinsCollected += ShowVictory;
    }

    private void OnDisable()
    {
        _coinCollector.AllCoinsCollected -= ShowVictory;
    }
    
    private void ShowVictory()
    {
        _victoryText.gameObject.SetActive(true);
    }
}
