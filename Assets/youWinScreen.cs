using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class youWinScreen : MonoBehaviour
{
    public Text pointsText;
    public void setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
    }

    public void restartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
