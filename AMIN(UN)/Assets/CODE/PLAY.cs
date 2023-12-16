using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAY : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        rb.AddForce(moveInput * speed);
    }
   
}
