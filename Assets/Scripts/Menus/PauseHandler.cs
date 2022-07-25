using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
	public GameObject pausePanel;
    public bool isPaused;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
		{
			if (isPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
    }

	public void Resume()
	{
		isPaused = false;
		Time.timeScale = 1;
		pausePanel.SetActive(false);
	}

	public void Exit()
	{
		Application.Quit();
	}

	private void Pause()
	{
		isPaused = true;
		Time.timeScale = 0;
		pausePanel.SetActive(true);
	}
}
