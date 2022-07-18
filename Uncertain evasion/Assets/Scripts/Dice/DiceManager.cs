using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public float diceValue;

    [SerializeField] GameObject dicePrefab;
    [SerializeField] Transform playerTransform;

    [Tooltip("Offset dice spawn position from player position")]
    [SerializeField] Vector3 offset;

    [SerializeField] EnemySpawner enemySpawner;

    private void Awake()
    {
        DiceFaceCheck.OnDiceStop += HandleDiceStop;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && enemySpawner.enemiesKilled >= 10)
        {
            SpawnDice();
            enemySpawner.enemiesKilled = 0;
        }
    }

    void SpawnDice()
    {
        GameObject obj = Instantiate(dicePrefab, playerTransform.position + offset, Quaternion.identity);
        Rigidbody rb = obj.GetComponent<Rigidbody>();

        // Creates random spin
        float dirX = Random.Range(0, 50);
        float dirY = Random.Range(0, 50);
        float dirZ = Random.Range(0, 50);

        rb.AddForce(playerTransform.forward * 12);
        rb.AddTorque(dirX, dirY, dirZ);
    }

    void HandleDiceStop(int value)
    {
        diceValue = value;
    }
}
