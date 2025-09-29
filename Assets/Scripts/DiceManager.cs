using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DiceManager : MonoBehaviour
{
    [SerializeField] private float velocityThreshold = 0.05f;
    [SerializeField] private float angularThreshold = 0.05f;
    [SerializeField] private float restTime = 0.3f;

    private readonly List<Dice> dice = new();
    private readonly Dictionary<Dice, float> timers = new();

    public void RegisterDice(Dice die)
    {
        dice.Add(die);
    }

    public void RollAll(DiceThrower thrower, Vector3 dir, float minF, float maxF, float minT, float maxT)
    {
        timers.Clear();
        foreach (var die in dice)
        {
            timers[die] = 0f;
            float force = Random.Range(minF, maxF);
            float torque = Random.Range(minT, maxT);
            thrower.Throw(die, dir.normalized, force, torque);
        }
    }

    public void UpdateTimers()
    {
        foreach (var die in dice)
        {
            if (die.IsStopped(velocityThreshold, angularThreshold))
                timers[die] += Time.deltaTime;
            else
                timers[die] = 0f;
        }
    }

    public bool AllStopped() => timers.Values.All(t => t >= restTime);

    public int GetTotal(DiceReader reader) =>
        dice.Sum(d => reader.ReadTopFace(d));
}