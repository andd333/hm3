using UnityEngine;

public class DiceThrower
{
    public void Throw(Dice dice, Vector3 direction, float force, float torque)
    {
        Rigidbody rb = dice.GetRigidbody();

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.AddForce(direction * force, ForceMode.Impulse);
        rb.AddTorque(Random.onUnitSphere * torque, ForceMode.Impulse);
    }
}