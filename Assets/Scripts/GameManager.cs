using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    private void Update()
    {   //if the game is waiting and player click play(jump)
        if (Time.timeScale == 0f && Input.GetAxisRaw("Jump") != 0)
            Play();
    }

    public void Play()
    {   //run the time
        Time.timeScale = 1f;
    }

    public void Restart()
    {   //reload scene
        SceneManager.LoadScene(0);
    }
}
