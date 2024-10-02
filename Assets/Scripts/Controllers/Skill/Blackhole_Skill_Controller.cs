using UnityEngine;

public class Blackhole_Skill_Controller : MonoBehaviour
{
    private float maxSize= 15;
    private float growSpeed= 1;

    private bool canGrow = true;

    private void Update()
    {


        if (canGrow)
        {
            // lerp allows us to transition slowly towards the end
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(maxSize, maxSize), growSpeed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            collision.GetComponent<Enemy>().FreezeTime(true);
        }
    }
}