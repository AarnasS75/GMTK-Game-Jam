using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    private Transform[] spawnPoints;

    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private int enemiesToSpawnCount = 0;
    [SerializeField] private float spawnDelay = 1f;

    public int enemiesKilled = 0;
    public TMP_Text enemiesToDiceTxt;

    private void Awake()
    {
        DiceFaceCheck.OnDiceStop += HandleEnemySpawning;
    }

    private void Start()
    {
        spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            spawnPoints[i] = transform.GetChild(i).transform;
        }

        StartCoroutine(BeginEnemySpawning());
    }

    void Update()
    {
        enemiesToDiceTxt.text = "Enemies killed for dice" + enemiesKilled +"/10";
    }

    private IEnumerator BeginEnemySpawning()
    {
        int count = 0;
        while (count < enemiesToSpawnCount)
        {
            CreateEnemy();
            count++;
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void CreateEnemy()
    {
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
        int randomEnemyIndex = Random.Range(0, enemyPrefab.Length);
        GameObject enemy = Instantiate(enemyPrefab[randomEnemyIndex], spawnPoints[randomSpawnPointIndex]);
        enemy.GetComponent<Enemy>().OnEnemyDeath += HandleEnemyDeath;

        print("Enemy spawned");
    }
    private void HandleEnemyDeath()
    {
        enemiesKilled++;
    }
    private void HandleEnemySpawning(int diceValue)
    {
        enemiesToSpawnCount = diceValue;
        print($"Start spawning {enemiesToSpawnCount} enemies");
        StartCoroutine(BeginEnemySpawning());
    }


}
