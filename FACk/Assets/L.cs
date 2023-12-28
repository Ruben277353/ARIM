using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/c/Maximple
public class PlayerController : MonoBehaviour
{
    //создание элемента типа аниматора
     private Animator animator;
    private Rigidbody rigidbody;
    public float rotationSpeed = 10f;
    public float speed = 2f;
    public Transform groundCheckerTransform;
    public LayerMask notPlayerMask;
    public float jumpForce = 2f;
    public bool canMove = true;
    Vector2 rotation = Vector2.zero;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;
    public Transform playerCameraParent;


    // Start is called before the first frame update
    void Start()
    {
        //Подключение аниматора в программу в принципе
        rotation.y = transform.eulerAngles.y;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // если нажата клавиша , то перс разворачивается в её сторону
        Vector3 directionVector = new Vector3(h, 0, v);
        //Вращение персонажа именно что при нажатии
        if (directionVector.magnitude > Mathf.Abs(0.05f))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(directionVector), Time.deltaTime * rotationSpeed);
        //
        animator.SetFloat("movementSpeed", Vector3.ClampMagnitude(directionVector, 1).magnitude);


        Vector3 moveDir = Vector3.ClampMagnitude(directionVector, 1) * speed;
        rigidbody.velocity = new Vector3(moveDir.x, rigidbody.velocity.y, moveDir.z);
        rigidbody.angularVelocity = Vector3.zero;

     /*   if (canMove)
        {
            rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
            rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
            playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
            transform.eulerAngles = new Vector2(0, rotation.y);
        }*/

        //Прыжок
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //      Jump();
        //  }
        //if (Physics.CheckSphere(groundCheckerTransform.position, 0.2f, notPlayerMask))
        // {
        //       animator.SetBool("isInAir", false);
        //   }
        //   else
        //   {
        //       animator.SetBool("isInAir", true);
        //  }

        //}

        void Jump()
        {
            if (Physics.Raycast(groundCheckerTransform.position, Vector3.down, 1f, notPlayerMask))
            {
                //подключение анимации прыжка
                // animator.SetTrigger("Jump");
                rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            else
            {
                Debug.Log("Did not find ground layer");
            }
        }
    }
}

