using UnityEngine;

public class Enemy_SideWays : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private int movementDistance;
    [SerializeField] private int Speed;
    [SerializeField] private int health; 
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    private float scaleX;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
        scaleX = transform.localScale.x;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        if (movingLeft)
        {
            if(transform.position.x > leftEdge) {//while the enemy doesn't rech the left edge move left 
                transform.localScale = new Vector3(scaleX, transform.localScale.y);//flip the enemy
                transform.position = new Vector3(transform.position.x - Speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge)//while the enemy doesn't rech the right edge move right
            {
                transform.localScale = new Vector3(-scaleX,transform.localScale.y);//flip the enemy
                transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = true;
            }
        }
    }

    //player gethit when touch enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().takeDamage(damage);
        }
    }
    
    //gethit function
    public void getHit()
    {
        spriteRenderer.color = new Color(1f, spriteRenderer.color.g - (1f / health), spriteRenderer.color.b - (1f / health), spriteRenderer.color.a);
        health -= 1;
        if (health == 0) { 
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
        }
    }
}
