using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator; // opcjonalnie do edycji animacji
    [SerializeField] private float _jumpForce;

    [SerializeField] private GameManager _gameManager;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            _rb.linearVelocity = Vector2.zero;
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _gameManager.Restart();
    }
}
