using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform _targetPoint;    
    private int _currentPoint;
    [SerializeField] private List<Transform> _points;
    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _targetPoint = _points[_currentPoint];

        transform.position = Vector2.MoveTowards(transform.position, _targetPoint.position, _moveSpeed * Time.deltaTime);

        if (transform.position.x == _targetPoint.position.x)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Count)
            {
                _currentPoint = 0;
            }
        }

        if (transform.position.x > _targetPoint.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (transform.position.x < _targetPoint.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
