using UnityEngine;
using UnityEngine.UI;

public class startScreen : MonoBehaviour
{
    public InputField nameField;
    public Text nameText;
    public Button play;

    private void Awake()
    {
        Time.timeScale = 0;
    }
    private void Update()
    {
        nameText.text= nameField.text;
    }
}
