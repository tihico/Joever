using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject[] BossPrefab;
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 2f;
    [SerializeField] private float difficultyScaling = 0.5f;

    [SerializeField] private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;

    public static UnityEvent onEnemyDestroy = new UnityEvent();
    private SceneLoader _scene;

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
        _scene = FindAnyObjectByType<SceneLoader>();
        StartCoroutine(StartWave());
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
        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0 )
        {
            EndWave();
        }
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
        Debug.Log(enemiesAlive + "enemiesAlive");
    }
    private IEnumerator StartWave()
    {
        
        Debug.Log("Wave started");
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }
    
    private void EndWave()
    {
        Debug.Log("Wave ended");
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        _scene.LoadScene(currentWave);
        StartCoroutine(StartWave());
    }
    private void SpawnEnemy()
    {
        if (enemyPrefabs == null || enemyPrefabs.Length == 0) return;
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject prefabToSpawn = enemyPrefabs[randomIndex];
        Debug.Log("Spawn Enemy");
        Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        timeSinceLastSpawn = 0f;
        // change transform later 


       if (currentWave == 10)
        {
            GameObject BossSpawner = BossPrefab[0];
            Instantiate(BossSpawner, transform.position, Quaternion.identity);
        }
    }


    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScaling));
    }
}
