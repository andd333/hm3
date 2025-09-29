using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    public bool IsStopped(float vel, float ang) =>
        rb.linearVelocity.magnitude <= vel && rb.angularVelocity.magnitude <= ang;

    public void ResetPhysics()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
    }

    public Rigidbody GetRigidbody() => rb;
}