using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    private Rigidbody2D _rb;

    [SerializeField] private Rigidbody2D _bulletPrefab;
    [SerializeField] private float _shootingRatio = 1f;
    [SerializeField] private float _bulletSpeed = 12.5f;
    
    private Vector2 _attackInput;
    private bool _isAttacking;
    private Coroutine _attackCoroutine;

    private float _timer = 0f;
    [SerializeField] private GameManager _gameManager;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _timer+=Time.deltaTime;
    }

    void OnMove(InputValue value)
    {
        Vector2 move = value.Get<Vector2>();
        _rb.linearVelocity = move * _speed;
    }

    public void OnAttack(InputValue value)
    {
        _attackInput = value.Get<Vector2>();
        bool activeInput = _attackInput != Vector2.zero;

        if (activeInput && !_isAttacking)
        {
            _isAttacking = true;
            _attackCoroutine = StartCoroutine(ShootContinuously());
        }
        else if (!activeInput && _isAttacking)
        {
            _isAttacking = false;
            StopCoroutine(_attackCoroutine);
        }
    }

    private IEnumerator ShootContinuously()
    {
        while (_isAttacking)
        {
            if (_timer >= _shootingRatio)
            {
                Shoot();
                _timer = 0f;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private void Shoot()
    {
        if (_attackInput == Vector2.zero)
            return;

        Rigidbody2D proj = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        proj.linearVelocity = _attackInput.normalized * _bulletSpeed;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Enemy")) ;
        _gameManager.Reset();
    }
}
