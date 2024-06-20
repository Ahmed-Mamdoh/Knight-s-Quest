using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] public int startingHealth;
    public int currentHealth;
    private Animator anim;
    private bool dead = false;
    [SerializeField] private AudioClip dieClip;
    [SerializeField] private AudioClip hurtClip;
    public gameOverScreen gameOverScreen;
    public Text heartText;


    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        heartText.text = currentHealth.ToString();
    }

    public void takeDamage(int damage)
    {
        currentHealth = Mathf.Max(currentHealth-damage,0);
        heartText.text = currentHealth.ToString();

        if (currentHealth > 0) {
            anim.SetTrigger("hurt");
            soundManager.instance.playSound(hurtClip);
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                soundManager.instance.playSound(dieClip);
                GetComponent<PlayerMovement>().enabled = false;
                GetComponent<Player>().enabled = false;
                dead = true;
                gameOverScreen.setup(GetComponent<PlayerMovement>().cm.coinCount);
            }
        }
    }
}
