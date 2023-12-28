using UnityEngine;

public class NPC2 : MonoBehaviour
{
    public Transform[] waypoints; // ћассив точек назначени€
    public float speed = 5f; // —корость движени€
    private int currentWaypointIndex = 0; // »ндекс текущей точки назначени€


    void Update()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            // ѕолучаем позицию текущей точки назначени€
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            // ¬ычисл€ем вектор направлени€ к текущей точке
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            // ѕеремещаем персонаж в направлении текущей точки
            transform.Translate(moveDirection * speed * Time.deltaTime);

            // ¬ычисл€ем угол поворота к текущей точке
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            // ѕоворачиваем персонаж в направлении текущей точки
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime);

            // ≈сли персонаж достиг текущей точки, переходим к следующей
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                currentWaypointIndex++;
            }
        }
    }
}