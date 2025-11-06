using TMPro;
using UnityEngine;

public class DefeatNotification : MonoBehaviour
{
    [SerializeField] private GameObject _defeatNotification;

    private void OnEnable()
    {
        GlobalEvents.OnPlayerKilled += ShowDefeatText;
    }

    private void OnDisable()
    {
        GlobalEvents.OnPlayerKilled -= ShowDefeatText;
    }

    private void ShowDefeatText()
    {
        _defeatNotification.SetActive(true);
    }
}
