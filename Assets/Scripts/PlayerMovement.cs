using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = .15f;
    private Vector2 _moveDirection;

    private Vector2 _shootDirection;
    [SerializeField] private Rigidbody2D _bulletPrefab;
    [SerializeField] private float _shootingRatio = 1f;
    [SerializeField] private float _bulletSpeed = 12.5f;
    private float _timer = 0f;

    [SerializeField] private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _shootDirection = new Vector2(Input.GetAxisRaw("FireHorizontal"), Input.GetAxisRaw("FireVertical"));
    }

	private void FixedUpdate()
	{
		if (_rb != null)
        {
            _rb.transform.position = (Vector2)_rb.transform.position + _moveDirection * _speed;
        }
        if(_shootDirection != Vector2.zero)
        {
			if (_timer > _shootingRatio)
			{
				Rigidbody2D bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
				bullet.velocity = _shootDirection * _bulletSpeed;
				_timer = 0;
			}		}
        _timer += Time.deltaTime;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.tag == "Enemy")
            _gameManager.Reset();
	}
}
