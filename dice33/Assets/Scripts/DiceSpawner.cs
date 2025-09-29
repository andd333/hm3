using UnityEngine;

public class DiceSpawner : MonoBehaviour
{
    [SerializeField] private GameObject dicePrefab;
    [SerializeField] private int diceCount = 3;
    [SerializeField] private Vector3 spawnAreaCenter = Vector3.zero;
    [SerializeField] private Vector3 spawnAreaSize = new Vector3(5, 0, 5);
    [SerializeField] private DiceManager manager;

    private void Start()
    {
        for (int i = 0; i < diceCount; i++)
        {
            Vector3 pos = spawnAreaCenter + new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                2f,
                Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
            );

            GameObject diceObj = Instantiate(dicePrefab, pos, Quaternion.identity);
            Dice dice = diceObj.GetComponent<Dice>();
            manager.RegisterDice(dice);
        }
    }
}