using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerHere : MonoBehaviour
{
    public Transform GG;
    public float distance = 3f;
    public GameObject Dialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = GG.position;
        Vector3 moveDirection = (targetPosition - transform.position);
        if (Vector3.Distance(transform.position, targetPosition) < distance)
        {
            Dialogue.SetActive(true);
        }
        else Dialogue.SetActive(false);
    }
}
