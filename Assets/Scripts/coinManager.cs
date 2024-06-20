using UnityEngine;
using UnityEngine.UI;

public class coinManager : MonoBehaviour
{
    public int coinCount;
    public Text coinText;
    void Update()
    {
        coinText.text =coinCount.ToString();
    }
}
