using UnityEngine;

public class Clone_Skill_Controller : MonoBehaviour
{
    private SpriteRenderer sr;

    private float cloneTimer = 1.5f;
    [SerializeField] private float colorLoosingSpeed;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        cloneTimer -= Time.deltaTime;

        if (cloneTimer < 0)
        {
            sr.color = new Color(1, 1, 1, sr.color.a - (Time.deltaTime * colorLoosingSpeed));

            if (sr.color.a <= 0)
                Destroy(gameObject);
        }
    }

    public void SetupClone(Transform _newTransform, Vector3 _offset, float _cloneDuration)
    {
        transform.position = _newTransform.position;
        cloneTimer = _cloneDuration;
    }


}