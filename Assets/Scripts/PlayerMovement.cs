using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 3.5f;   //value of force added when jump
    private bool _jump = false; //is jump button active
    private Rigidbody2D _rb;    //this object rigidbody
    [SerializeField] private GameManager _gameManager;  //Script from GameController object

    // Start is called before the first frame update
    void Start()
	{   //set rb
		_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
	{   //if jump button active set true else - false
		_jump = Input.GetAxisRaw("Jump") == 1 ? true : false;   
    }

	//FixedUpdate is called every fixed frame-rate frame
	private void FixedUpdate()
	{   //if jump active
		if (_jump)
			//add force to vertical axis (Y) in rb
			_rb.velocity = Vector2.up * _jumpForce; 
	}

	//Sent when an incoming collider makes contact with this object's collider (2D physics only)
	private void OnCollisionEnter2D(Collision2D collision)
	{    //restart scene
		_gameManager.Restart();
	}
}
