
using UnityEngine;

public class Sword_Skill_Controller : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private CircleCollider2D cd;
    private Player player;

    private bool canRotate = true;
    private bool isReturning;

    private float returnSpeed = 12;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();
    }

    public void SetupSword(Vector2 _dir, float _gravityScale, Player _player)
    {
        player = _player;
        rb.velocity = _dir;
        rb.gravityScale = _gravityScale;
    }

    public void ReturnSword()
    {
        
        rb.isKinematic = false;
        transform.parent = null;
        isReturning = true;
        //rb.constraints = RigidbodyConstraints2D.FreezeAll;

        // sword.skill.setcooldown;
    }

    private void Update()
    {
        if (canRotate) { 
            transform.right = rb.velocity;
        }

        if (isReturning)
        {
            //we return the sword to the player
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, returnSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, player.transform.position) < 1) { 
                player.ClearTheSword();
            }
        }
    }

    // is being callde when collider is triggered (Is trigger checkbox)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canRotate = false;
        cd.enabled = false;

        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        //we made a collided object a child of an object it collided to
        transform.parent = collision.transform;

    }
}
