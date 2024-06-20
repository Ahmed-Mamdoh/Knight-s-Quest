using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // initialize variables
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    [SerializeField] private float speed;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip coinClip;
    public youWinScreen youWinScreen;

    public coinManager cm;

    private void Awake()
    {
        //Grabe Refrences
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        //right-left movement
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y) ;

        //flip player when moving right-left
        if (horizontalInput > 0.0f)
            transform.localScale = new Vector3(1.2f,1.2f,1);
        else if (horizontalInput < 0.0f)
            transform.localScale = new Vector3(-1.2f, 1.2f, 1);

        //jumping
        if (Input.GetKey(KeyCode.Space) && grounded) jump();
        if (Input.GetKeyDown(KeyCode.LeftControl) && grounded) roll();

        //set animation parameter
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    //jump function
    private void jump() {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
        soundManager.instance.playSound(jumpClip);
    }

    //ground collision check 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
            grounded= true;
    }

    private void roll()
    {
        anim.SetTrigger("roll");
    }

    public bool canAttack()
    {
        return grounded;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "coin")
        {
            Destroy(other.gameObject);
            cm.coinCount += 1;
            soundManager.instance.playSound(coinClip);
        }
        else if (other.gameObject.tag == "gem")
        {
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<Player>().enabled = false;
            youWinScreen.setup(GetComponent<PlayerMovement>().cm.coinCount);
        }
    }

}
