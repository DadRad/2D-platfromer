using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Collector _coinCollector;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _repeatRate;
    [SerializeField] private int _poolSize;
    [SerializeField] private int _maxPoolSize;

    private ObjectPool<Coin> _coinPool;
    private int _arrayIndex;

    private void Awake()
    {
        _coinPool = new ObjectPool<Coin>(
            createFunc: CreateCoin,
            actionOnGet: ActionOnGet,
            actionOnRelease: ActionOnRelease,
            actionOnDestroy: ActionOnDestroy,
            collectionCheck: true,
            defaultCapacity: _poolSize,
            maxSize: _maxPoolSize
        );
    }

    private Coin CreateCoin()
    {
        Coin coinInstance = Instantiate(_coinPrefab);
        coinInstance.gameObject.SetActive(false);
        return coinInstance;
    }

    private void ActionOnGet(Coin coin)
    {
        if (_arrayIndex < _spawnPoints.Length)
        {
            coin.transform.position = _spawnPoints[_arrayIndex].position;
        }

        coin.gameObject.SetActive(true);
    }

    private void ActionOnRelease(Coin coin)
    {
        coin.gameObject.SetActive(false);
    }

    private void ActionOnDestroy(Coin coin)
    {
        Destroy(coin.gameObject);
    }

    private void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    private void OnEnable()
    {
        _coinCollector.OnCoinCollected += ReleaseHandler;
    }

    private void OnDisable()
    {
        _coinCollector.OnCoinCollected -= ReleaseHandler;
    }

    private IEnumerator SpawnCoins()
    {
        WaitForSeconds wait = new WaitForSeconds(_repeatRate);

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _arrayIndex = i;
            _coinPool.Get();
            yield return wait;
        }
    }

    private void ReleaseHandler(GameObject coinObject)
    {
        if (coinObject.TryGetComponent<Coin>(out Coin coin))
        {
            _coinPool.Release(coin);
        }
        else
        {
            Debug.LogWarning("Объект не содержит компонент Coin", coinObject);
        }
    }
}
