using UnityEngine;

public class pauseScreen : MonoBehaviour
{
    public GameObject pausePanel;
    public bool paused = false; 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0;
                paused = true;
            }
            else {
                pausePanel.SetActive(false);
                Time.timeScale = 1;
                paused = false;
            }
        }
    }
}
