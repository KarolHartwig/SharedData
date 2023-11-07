using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField] float _speed = 2f;

	// FixedUpdate id called every fixed frame-rate frame
	void FixedUpdate()
    {
		transform.position += Vector3.left * _speed * Time.deltaTime;
	}
}
