using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private  Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.linearVelocity = Vector2.left * _speed;
    }
}
