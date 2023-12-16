using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed;

    void Start()
    {
        speed = 2;
    }
    // left = x; back = z;

    void Update()
    {
        if (transform.position.x < 115f)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (transform.position.z < 97f)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        else if (transform.position.x < -11f) 
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }


        if (transform.position.x < 90f )
        {
            speed = -speed;
        }

        if (transform.position.x > 115f && transform.position.z < 40f && transform.position.x > 11)
        {
            speed = 2;
        }
    }
}