using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prallax_script : MonoBehaviour
{
    private float length, startpos;
    public float scrollSpeed = 2f;
    public float parallaxEffect = 1f;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float dist = -Time.fixedTime * scrollSpeed * parallaxEffect;
        float temp = dist % length;

        transform.position = new Vector3(startpos + temp, transform.position.y, transform.position.z);
    }

}
