using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Prefab ve Noktalar")]
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    [Header("Dalga Ayarlar�")]
    public int enemiesPerWave = 3;              // �lk dalgada ka� d��man do�acak
    public float waveInterval = 2f;             // Dalgalar aras� s�re

    [Header("Zorluk Ayarlar�")]
    public float startSpawnInterval = 1.5f;     // �lk dalgalar aras� s�re
    public float minSpawnInterval = 0.5f;       // Minimum s�re (daha h�zl� olmas�n)
    public float difficultyIncreaseInterval = 10f; // Ka� saniyede bir zorluk arts�n
    public float spawnIntervalDecreaseAmount = 0.1f;
    public int maxEnemiesPerWave = 10;

    private float waveTimer;
    private float difficultyTimer;
    private float currentSpawnInterval;
    private int currentEnemiesPerWave;

    void Start()
    {
        currentSpawnInterval = startSpawnInterval;
        waveTimer = currentSpawnInterval;
        difficultyTimer = difficultyIncreaseInterval;
        currentEnemiesPerWave = enemiesPerWave;
    }

    void Update()
    {
        waveTimer -= Time.deltaTime;
        difficultyTimer -= Time.deltaTime;

        // Yeni dalga zaman� geldiyse
        if (waveTimer <= 0f)
        {
            StartCoroutine(SpawnWave());
            waveTimer = currentSpawnInterval;
        }

        // Zorluk art�rma zaman� geldiyse
        if (difficultyTimer <= 0f)
        {
            // Dalga s�resini azalt
            currentSpawnInterval = Mathf.Max(minSpawnInterval, currentSpawnInterval - spawnIntervalDecreaseAmount);

            // Ayn� anda do�acak d��man say�s�n� art�r
            if (currentEnemiesPerWave < maxEnemiesPerWave)
                currentEnemiesPerWave++;

            difficultyTimer = difficultyIncreaseInterval;
        }
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < currentEnemiesPerWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.2f); // D��manlar aras� k�sa gecikme
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null || spawnPoints.Length == 0)
        {
            Debug.LogWarning("Enemy Prefab veya spawn noktalar� ayarlanmam��.");
            return;
        }

        int index = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[index];

        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
