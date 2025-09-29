using UnityEngine;

public class DiceReader
{
    public int ReadTopFace(Dice dice)
    {
        float bestDot = -Mathf.Infinity;
        int bestSide = 1;
        for (int i = 1; i <= 6; i++)
        {
            var side = dice.transform.Find("side" + i);
            if (side == null) continue;
            float dot = Vector3.Dot(side.up, Vector3.up);
            if (dot > bestDot) { bestDot = dot; bestSide = i; }
        }
        return bestSide;
    }
}
