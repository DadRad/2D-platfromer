using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DefeatNotification : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _defeatText;

    private void OnEnable()
    {
        EventManager.Instance.PlayerKilled += ShowDefeatText;
    }

    private void OnDisable()
    {
        if (EventManager.Instance != null)
        {
            EventManager.Instance.PlayerKilled -= ShowDefeatText;
        }
    }

    private void ShowDefeatText()
    {
        _defeatText.gameObject.SetActive(true);
        Debug.Log("Defeat text activated!");
    }
}
