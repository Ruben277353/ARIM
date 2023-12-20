using UnityEngine;

public class SF : MonoBehaviour
{
    public  Collider[] otherColliders;
    public WheelCollider[] wheelColliders;

    void Start()
    {
        Collider thisCollider = GetComponent<Collider>();

        foreach (Collider collider in otherColliders)
        {
            Physics.IgnoreCollision(thisCollider, collider);
        }

        foreach (WheelCollider wheelCollider in wheelColliders)
        {
            Physics.IgnoreCollision(thisCollider, wheelCollider.GetComponent<Collider>());
        }
    }
}