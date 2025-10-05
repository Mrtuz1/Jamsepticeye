using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Prefab ve Noktalar")]
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    [Header("Dalga Ayarlarý")]
    public int enemiesPerWave = 3;              // Ýlk dalgada kaç düþman doðacak
    public float waveInterval = 2f;             // Dalgalar arasý süre

    [Header("Zorluk Ayarlarý")]
    public float startSpawnInterval = 1.5f;     // Ýlk dalgalar arasý süre
    public float minSpawnInterval = 0.5f;       // Minimum süre (daha hýzlý olmasýn)
    public float difficultyIncreaseInterval = 10f; // Kaç saniyede bir zorluk artsýn
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

        // Yeni dalga zamaný geldiyse
        if (waveTimer <= 0f)
        {
            StartCoroutine(SpawnWave());
            waveTimer = currentSpawnInterval;
        }

        // Zorluk artýrma zamaný geldiyse
        if (difficultyTimer <= 0f)
        {
            // Dalga süresini azalt
            currentSpawnInterval = Mathf.Max(minSpawnInterval, currentSpawnInterval - spawnIntervalDecreaseAmount);

            // Ayný anda doðacak düþman sayýsýný artýr
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
            yield return new WaitForSeconds(0.2f); // Düþmanlar arasý kýsa gecikme
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null || spawnPoints.Length == 0)
        {
            Debug.LogWarning("Enemy Prefab veya spawn noktalarý ayarlanmamýþ.");
            return;
        }

        int index = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[index];

        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
}
