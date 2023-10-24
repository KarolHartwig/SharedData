using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Transform[] _spawnPoints;
    private float _spawnTimer = 5f;
    [SerializeField] private GameObject _enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        _spawnPoints = GameObject.Find("EnemySpawnPoints").GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
		if (_spawnTimer < 0)
		{
			int enemiesCount = 1;//Random.Range(1, 6);
			//List<int> spawners = GenerateRandomList(enemiesCount);
			//for (int i = 0; i < enemiesCount; i++)
            //{
                Instantiate(_enemyPrefab, _spawnPoints[Random.Range(0, 13)].transform.position, Quaternion.identity);
            //}
			_spawnTimer = Random.Range(1f, 4f);
		}
		_spawnTimer -= Time.deltaTime;

	}
	/*public List<int> GenerateRandomList(int maxSpawns)
	{
		List<int> randomList = new List<int>();
		for (int i = 0; i < maxSpawns; i++)
		{
			int numToAdd = Random.Range(0, _spawnPoints.Length);
			while (!randomList.Contains(numToAdd))
			{
				numToAdd = Random.Range(0, _spawnPoints.Length);
			}
			randomList.Add(numToAdd);
		}
		return randomList;
	}*/
	public void Reset()
	{
        SceneManager.LoadScene(0);
	}
}
