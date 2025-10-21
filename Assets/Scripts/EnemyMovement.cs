using UnityEngine;

public class EnemyMovement : MonoBehaviour{
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Transform _player;
    private Vector2 _moveDirection;
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start(){
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.Find("Player").GetComponent<Transform>();
        _gameManager = GameObject.Find("GameController").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update(){
        Vector2 playerPos = _player.transform.position;
        _moveDirection = new Vector2(playerPos.x - transform.position.x, playerPos.y - transform.position.y).normalized;
    }
    private void FixedUpdate(){
        _rb.linearVelocity = _moveDirection * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.CompareTag($"Bullet")) {
            _rb.bodyType = RigidbodyType2D.Static;
            Destroy(gameObject, 2);
        }
    }
}

