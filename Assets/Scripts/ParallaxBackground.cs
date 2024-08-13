using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private GameObject cam;
    [SerializeField] private float parallaxEffect;

    private float xPosition;
    private float length;

    private Vector3 targetPosition;
    [SerializeField] private float lerpSpeed = 10;

    void Start()
    {
        cam = GameObject.Find("Main Camera");

        xPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToMove = cam.transform.position.x * parallaxEffect;
        targetPosition = new Vector3(xPosition + distanceToMove, transform.position.y, transform.position.z);
    }
}
