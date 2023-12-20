using UnityEngine;

public class NPC : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 3f;
    private int currentWaypointIndex = 0;

    void Update()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("No waypoints assigned!");
            return;
        }

        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetNextWaypoint();
        }
    }

    void SetNextWaypoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }
}