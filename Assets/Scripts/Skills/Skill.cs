using UnityEngine;

public  class Skill : MonoBehaviour
{
    [SerializeField] public float cooldown;
    public float cooldownTimer;


    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        cooldownTimer -= Time.deltaTime;
    }

    public virtual bool CanUseSkill()
    {
        if (cooldownTimer < 0)
        {
            UseSkill();
            cooldownTimer = cooldown;
            return true;
        }


        return false;
    }

    public virtual void UseSkill()
    {
        // do some skill spesific things
    }
}