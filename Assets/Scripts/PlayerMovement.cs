using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 3.5f;   //value of force added when jump
    private Rigidbody2D _rb;    //this object rigidbody
    [SerializeField] private GameManager _gameManager;  //Script from GameController object
	private Animator _animator;
    // Start is called before the first frame update
    void Start()
	{   //set rb
		_rb = GetComponent<Rigidbody2D>();
		//set animator
		_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
	{   //if jump button active set true else - false
		if (Input.GetMouseButtonDown(0))
		{
			//add force to vertical axis (Y) in rb
			_rb.velocity = Vector2.up * _jumpForce;
			//play animation
			PlayAnimation();
		}
    }

	//Sent when an incoming collider makes contact with this object's collider (2D physics only)
	private void OnCollisionEnter2D(Collision2D collision)
	{    //restart scene
		_gameManager.Restart();
	}

	private void PlayAnimation()
	{
		_animator.Play("Player_flap");
	}
}
