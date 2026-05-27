using UnityEngine;

public class Coin : MonoBehaviour
{   
    private bool _isCollected = false;

    public bool IsCollected => _isCollected;

    public event System.Action<Coin> CoinCollected;

    public void Collect()
    {
        _isCollected = true;
        CoinCollected?.Invoke(this);
    }
}
