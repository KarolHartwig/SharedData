using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
