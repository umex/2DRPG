using UnityEngine;

public class Sword_Skill : Skill
{
    [Header("Skill info")]
    [SerializeField] private GameObject swordPrefab;
    [SerializeField] private Vector2 launchForce;
    [SerializeField] private float swordGravity;


    private Vector2 finalDir;

    public void CreateSword()
    {
        GameObject newSword = Instantiate(swordPrefab, player.transform.position, transform.rotation);
        Sword_Skill_Controller newSwordScript = newSword.GetComponent<Sword_Skill_Controller>();


        newSwordScript.SetupSword(launchForce, swordGravity, player);
    }

    #region Aim region
    public Vector2 AimDirection()
    {
        Vector2 playerPosition = player.transform.position; //starting point
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //final point
        Vector2 direction = mousePosition - playerPosition;

        return direction;
    }
    #endregion
}