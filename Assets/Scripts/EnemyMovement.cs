using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Vector2 _player;
    private Vector2 _moveDirection;
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _gameManager = GameObject.Find("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
		_player = GameObject.Find("Player").GetComponent<Transform>().transform.position;
        _moveDirection = new Vector2(_player.x - transform.position.x, _player.y - transform.position.y).normalized;
	}

	private void FixedUpdate()
	{
		_rb.velocity = _moveDirection * _speed;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.tag == "Bullet") {
            _rb.bodyType = RigidbodyType2D.Static;
			
			Destroy(gameObject, 2);
        }
	}
}
