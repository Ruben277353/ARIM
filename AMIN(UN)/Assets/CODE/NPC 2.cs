using UnityEngine;

public class NPC2 : MonoBehaviour
{
    public Transform[] waypoints; // ������ ����� ����������
    public float speed = 5f; // �������� ��������
    private int currentWaypointIndex = 0; // ������ ������� ����� ����������


    void Update()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            // �������� ������� ������� ����� ����������
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            // ��������� ������ ����������� � ������� �����
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            // ���������� �������� � ����������� ������� �����
            transform.Translate(moveDirection * speed * Time.deltaTime);

            // ��������� ���� �������� � ������� �����
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            // ������������ �������� � ����������� ������� �����
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime);

            // ���� �������� ������ ������� �����, ��������� � ���������
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentWaypointIndex++;
            }
        }
    }
}