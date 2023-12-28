
using Cinemachine.Utility;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 3f;
    private int currentWaypointIndex = 0;
    public float rotationSpeed = 5f;
    CharacterController G;
    private void Start()
    {
        G = GetComponent<CharacterController>();
    }

    void Update()
    {

        if (waypoints.Length == 0)
        {
            Debug.LogError("No waypoints assigned!");
            return;
        }

        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * rotationSpeed);
        G.Move(moveDirection * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {

            SetNextWaypoint();

        }

    }

    void SetNextWaypoint()
    {
        //transform.Rotate(Vector3.up, -90f); 

        int nextWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

        // ѕровер€ем, если следующа€ точка назначени€ равна текущей позиции, то выбираем следующую точку 
        if (waypoints[nextWaypointIndex].position == transform.position)
        {

            nextWaypointIndex = (nextWaypointIndex + 1) % waypoints.Length;
        }

        currentWaypointIndex = nextWaypointIndex;
    }
}