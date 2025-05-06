using UnityEngine;

public class Crystal_Skill : Skill
{
    [SerializeField] private float crystalDuration;
    [SerializeField] private GameObject crystalPrefab;
    private GameObject currentCrystal;

    public override void UseSkill()
    {
        base.UseSkill();

        if (currentCrystal == null)
        {
            CreateCrystal();
        }
        else
        {
            player.transform.position = currentCrystal.transform.position;
            Destroy(currentCrystal);
        }
        
    }

    public void CreateCrystal()
    {
        currentCrystal = Instantiate(crystalPrefab, player.transform.position, Quaternion.identity);
        Crystal_Skill_Controller currentCystalScript = currentCrystal.GetComponent<Crystal_Skill_Controller>();

        currentCystalScript.SetupCrystal(crystalDuration);
    }
}
