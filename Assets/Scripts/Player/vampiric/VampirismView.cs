using UnityEngine;

public class VampirismView : MonoBehaviour
{
    [SerializeField] private GameObject _vampirismRadius;

    private void Awake()
    {
        if (_vampirismRadius != null)
            _vampirismRadius.SetActive(false);
    }

    public void StartAbility()
    {
        if (_vampirismRadius != null)
            _vampirismRadius.SetActive(true);
    }

    public void Stop()
    {
        if (_vampirismRadius != null)
            _vampirismRadius.SetActive(false);
    }
}