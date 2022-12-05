using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningCoins : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private Coin _coin;
    [SerializeField] private float _rndXMinPosition;
    [SerializeField] private float _rndXMaxPosition;

    private Coin _spawnedCoin;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        while (true)
        {
            _spawnedCoin = Instantiate(_coin, new Vector2(Random.Range(_rndXMinPosition, _rndXMaxPosition), transform.position.y), Quaternion.identity);

            yield return new WaitForSeconds(_delay);
        }
    }
}
