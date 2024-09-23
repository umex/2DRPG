using UnityEngine;

public  class Skill : MonoBehaviour
{
    [SerializeField] public float cooldown;
    public float cooldownTimer;

    protected Player player;



    protected virtual void Start()
    {
        player = PlayerManager.instance.player;
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