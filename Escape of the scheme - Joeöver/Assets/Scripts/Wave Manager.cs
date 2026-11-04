using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private Button startWaveButton;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 2f;
    [SerializeField] private float difficultyScaling = 0.5f;

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;

    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
       // StartCoroutine(StartWave());
        Debug.Log("Wave started");
    }
    private void Update()
    {
        if (!isSpawning) return;
        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }
        if (enemiesAlive == 0 && enemiesLeftToSpawn <= 0 )
        {
            EndWave();
        }
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
        if (enemiesAlive < 0) enemiesAlive = 0;
        Debug.Log(enemiesAlive + "enemiesAlive");
    }
    private IEnumerator StartWave()
    {
        Debug.Log("Wave started");
       // startWaveButton.interactable = false;
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }
    
    private void EndWave()
    {
        Debug.Log("Wave ended");
       // startWaveButton.interactable = false;
        isSpawning = false;
        timeSinceLastSpawn = 1f;
        currentWave++;
        StartCoroutine(StartWave());
    }
    public void SpawnEnemy()
    {
        if (enemyPrefabs == null || enemyPrefabs.Length == 0) return;
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject prefabToSpawn = enemyPrefabs[randomIndex];
        Debug.Log("Spawn Enemy");
        Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        timeSinceLastSpawn = 0f;
        // change transform later 
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScaling));
    }

}
