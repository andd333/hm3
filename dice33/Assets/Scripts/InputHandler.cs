using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private DiceManager manager;
    [SerializeField] private Vector3 throwDir = new(0, 1, 1);
    [SerializeField] private float minForce = 6f;
    [SerializeField] private float maxForce = 10f;
    [SerializeField] private float minTorque = 5f;
    [SerializeField] private float maxTorque = 12f;

    private readonly DiceThrower thrower = new();
    private readonly DiceReader reader = new();
    private bool isRolling = false;

    public void OnRoll(InputAction.CallbackContext ctx)
    {
        if (ctx.started && !isRolling)
        {
            isRolling = true;
            manager.RollAll(thrower, throwDir, minForce, maxForce, minTorque, maxTorque);
        }
    }

    private void Update()
    {
        if (!isRolling) return;

        manager.UpdateTimers();

        if (manager.AllStopped())
        {
            isRolling = false;
            int sum = manager.GetTotal(reader);
            Debug.Log($"🎲 Сумма: {sum}");
        }
    }
}