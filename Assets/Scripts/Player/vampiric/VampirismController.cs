using UnityEngine;

[RequireComponent(typeof(Vampirism))]
[RequireComponent(typeof(VampirismView))]
[RequireComponent(typeof(InputReader))]
public class VampirismController : MonoBehaviour
{
    private Vampirism _vampirism;
    private VampirismView _view;
    private InputReader _inputReader;

    private void Awake()
    {
        _vampirism = GetComponent<Vampirism>();
        _view = GetComponent<VampirismView>();
        _inputReader = GetComponent<InputReader>();

        _vampirism.Activated += _view.StartAbility;
        _vampirism.Deactivated += _view.Stop;
    }

    private void OnDestroy()
    {
        _vampirism.Activated -= _view.StartAbility;
        _vampirism.Deactivated -= _view.Stop;
    }

    private void Update()
    {
        if (_inputReader == null) 
            return;

        if (_inputReader.VampirismAbilityUsed)
        {
            _vampirism.TryActivate();
        }
    }
}