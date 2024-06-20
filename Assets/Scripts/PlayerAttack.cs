using UnityEngine;

public class Player : MonoBehaviour
{
    //initialize variables
    [SerializeField] private float attackCooldown;
    private Animator anim;
    private PlayerMovement playerMovement;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    [SerializeField] private AudioClip attackClip;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && playerMovement.canAttack()) {
            attack();
        }
    }

    //attack function
    private void attack()
    {
        soundManager.instance.playSound(attackClip);
        anim.SetTrigger("attack");//animation trigger
        Collider2D[]hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);//array of hitted enemys

        foreach(Collider2D enemy in hitEnemys)
        {
            enemy.GetComponent<Enemy_SideWays>().getHit();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
