
using UnityEngine;

public class Sword_Skill_Controller : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private CircleCollider2D cd;
    private Player player;

    private bool canRotate = true;

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

    private void Update()
    {
        if (canRotate) { 
            transform.right = rb.velocity;
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
