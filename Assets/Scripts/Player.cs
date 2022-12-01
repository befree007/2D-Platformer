using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [HideInInspector] public int _coinCount;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal"), _rigidbody2D.velocity.y) * _moveSpeed;
        _animator.SetFloat("Run", Mathf.Abs(Input.GetAxis("Horizontal")));

        if (_rigidbody2D.velocity.x > transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (_rigidbody2D.velocity.x < transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Coin>(out Coin coin))
        {
            _coinCount += 1;
            Destroy(collision.gameObject);
        }
        else if (collision.collider.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Destroy(gameObject);
        }
    }
}
