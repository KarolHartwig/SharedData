using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private float _timeToSpawn = 5;
    [SerializeField] private GameObject _pipe;
    [SerializeField] private float _height = 2.5f;
    private float _timer;

    private void Update(){
        if (_timer > _timeToSpawn){
            GameObject newPipe = Instantiate(_pipe, Vector3.zero, Quaternion.identity);
            newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-_height, _height) + 1.5f, 0);
            Destroy(newPipe, 6f);
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }
}
