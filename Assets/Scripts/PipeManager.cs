using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
	//duration between spawns
	[SerializeField] private float _timeToSpawn = 4f;
	//prefab
	[SerializeField] private GameObject _pipe;
	//vertical position range
	[SerializeField] private float _height = 1.5f;
	private float _timer;

	//Update is called once per frame
	private void Update()
	{
		//if enough time has passed
		if (_timer > _timeToSpawn)
		{
			//create obstacle
			GameObject newPipe = Instantiate(_pipe, Vector3.zero, Quaternion.identity);
			//set vertical position
			newPipe.transform.position = transform.position 
				+ new Vector3(0, Random.Range(-_height, _height)+.5f, 0);
			//destroy after 6 seconds
			Destroy(newPipe, 10f);
			//reset timer
			_timer = 0;
		}
		//increase the timer by the elapsed time
		_timer += Time.deltaTime;
	}
}