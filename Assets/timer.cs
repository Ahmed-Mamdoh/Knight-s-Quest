using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text time;
    private float elapsedTime; 

    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        time.text = string.Format("{0:00}:{1:00}" , minutes, seconds);
    }
}
