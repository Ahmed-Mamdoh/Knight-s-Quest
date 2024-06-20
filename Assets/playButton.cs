using UnityEngine;

public class playButton : MonoBehaviour
{
    public GameObject playscreen;
    bool playing = false;
    private void Update()
    {
        if(playscreen.active == false && playing == false)
        {
            Time.timeScale = 1;
            playing = true;
        }
    }
}
