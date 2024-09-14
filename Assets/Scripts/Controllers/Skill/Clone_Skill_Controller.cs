using System.Collections;
using System.Linq;
using UnityEditor.Search;
using UnityEngine;

public class Clone_Skill_Controller : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator anim;

    private float cloneTimer = 1.5f;
    [SerializeField] private float colorLoosingSpeed;
    [SerializeField] private Transform attackCheck;
    [SerializeField] private float attackCheckRadius = .8f;
    private int facingDir = 1;


    [SerializeField] private float closestEnemyCheckRadius = 25;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        cloneTimer -= Time.deltaTime;

        if (cloneTimer < 0)
        {
            sr.color = new Color(1, 1, 1, sr.color.a - (Time.deltaTime * colorLoosingSpeed));

            // destroys gameobject when it becomes transaparent.  
            // So that clones are not kept in memmory
            if (sr.color.a <= 0)
                Destroy(gameObject);
        }
    }

    public void SetupClone(Transform _newTransform, Vector3 _offset, float _cloneDuration, bool _canAttack)
    {
        if (_canAttack)
            anim.SetInteger("AttackNumber", Random.Range(1, 3));

        transform.position = _newTransform.position;
        cloneTimer = _cloneDuration;

        FaceClosestTarget();
    }

    private void AnimationTrigger()
    {
        cloneTimer = -.1f;
    }

    private void AttackTrigger()
    {
        // we will get all colliders but only interact with specific inside of our attackCheck gizmo 
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackCheck.position, attackCheckRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                hit.GetComponent<Enemy>().Damage();
            }
        }
    }

    private void FaceClosestTarget()
    {
        // gets all the object in the distance of 25 of player (oir clone in this matter)
        var closestEnemy = Physics2D.OverlapCircleAll(transform.position, 25)
            .Where(hit => hit.GetComponent<Enemy>() is not null)
            .OrderBy(hit => Vector2.Distance(transform.position, hit.transform.position))
            .FirstOrDefault();

        if (closestEnemy != null)
        {
            if (transform.position.x > closestEnemy.GetComponent<Transform>().position.x)
            {
                transform.Rotate(0, 180, 0);
            }
        }

    }
}