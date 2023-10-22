using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   //set time to 0 and wait for player
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
