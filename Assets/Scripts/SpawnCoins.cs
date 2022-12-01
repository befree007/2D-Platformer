using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private Coin _coin;
    [SerializeField] private float _rndXMinPosition;
    [SerializeField] private float _rndXMaxPosition;
    private float _rndXPosition;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        while (true)
        {
            _rndXPosition = Random.Range(_rndXMinPosition, _rndXMaxPosition);
            Instantiate(_coin, new Vector2(_rndXPosition, transform.position.y), Quaternion.identity);

            yield return new WaitForSeconds(_delay);
        }
    }
}
