using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinCollector _coinCollector;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _repeatRate;
    [SerializeField] private int _poolSize;
    [SerializeField] private int _maxPoolSize;

    private ObjectPool<GameObject> _coinPool;
    private int _arrayIndex;

    private void Awake()
    {
        _coinPool = new ObjectPool<GameObject>(
            createFunc: () => Instantiate(_coinPrefab),
            actionOnGet: (coin) => ActionOnGet(coin),
            actionOnRelease: (coin) => coin.SetActive(false),
            actionOnDestroy: (coin) => Destroy(coin),
            collectionCheck: true,
            defaultCapacity: _poolSize,
            maxSize: _maxPoolSize
        );
    }

    private void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    private void OnEnable()
    {
        _coinCollector.OnCoinCollected += ReleaseHandler;
    }

    private void ActionOnGet(GameObject coin)
    {
        coin.transform.position = _spawnPoints[_arrayIndex].position;
        coin.gameObject.SetActive(true);
    }

    private void GetCoin()
    {
        GameObject coin = _coinPool.Get();
    }

    private IEnumerator SpawnCoins()
    {
        var wait = new WaitForSeconds(_repeatRate);

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _arrayIndex = i;
            GetCoin();
            yield return wait;
        }
    }
    
    private void ReleaseHandler(GameObject coin)
    {
        _coinPool.Release(coin);
    }
}
