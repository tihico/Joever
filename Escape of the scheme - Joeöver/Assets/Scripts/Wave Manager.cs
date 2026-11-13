using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject enemyPrefab1;
    [SerializeField] private GameObject enemyPrefab2;
    [SerializeField] private GameObject enemyPrefab3;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 2f;
    [SerializeField] private int difficultyScaling = 2;
    [SerializeField] private Button Button1;
    [SerializeField] private GameObject[] LevelSpawn;

    [SerializeField] private int currentWave = 0;
    [SerializeField] private float timeSinceLastSpawn;
    [SerializeField] private int enemiesAlive;
    [SerializeField] private int enemiesLeftToSpawn;
    [SerializeField] private bool isSpawning = false;
    private bool bossSpawnedThisWave = false;

    public static UnityEvent onEnemyDestroy = new UnityEvent();
    private SceneLoader _scene;

    private void Awake()
    {
        onEnemyDestroy.RemoveAllListeners();
        onEnemyDestroy.AddListener(EnemyDestroyed);
       // Debug.Log("Awake");
    }
       public void Button()
    {
        StartCoroutine(StartWave());
        Button1.interactable = false;
        _scene = FindAnyObjectByType<SceneLoader>();
       // Debug.Log("Start");
    }
    //public void Button()
    //{
    //    if (isSpawning) return;
    //    currentWave++;
    //    Debug.Log("Button Start");
    //    StartCoroutine(StartWave());
    //}
    private void Update()
    {
        if (!isSpawning) return;
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }
        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }
    private void EnemyDestroyed()
    {
        enemiesAlive--;
      //  Debug.Log(enemiesAlive + "enemiesAlive");
    }
    private IEnumerator StartWave()
    {

        //Debug.Log("Wave started");
        yield return new WaitForSeconds(timeBetweenWaves);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    private void EndWave()
    {
        Button1.interactable = true;
        Debug.Log("Wave ended");
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
       
        _scene.LoadScene(currentWave);
    }
    private void SpawnEnemy()
    {
        int randomSpawnIndex = UnityEngine.Random.Range(0, LevelSpawn.Length);
        Vector3 spawnPosition = LevelSpawn[randomSpawnIndex].transform.position;
        /*
         I want to either set the enemies myself per round or, randomize it because that sounds
        easier, besides that i want the amount of enemies to increase per round, by 2 or more or so
        then on the final wave i want the boss to spawn


        for each () {} randomizer
        if index = 1 spawn prefab tier 1 chud enemy
        if index = 2 spawn prefab tier 2 enemy
        if index = 3 spawn prefab anti bullet
        if wave 10 = spawn boss




         */
        //  if (enemyPrefabs == null || enemyPrefabs.Length == 0) return;
        /*  List<GameObject> prefabToSpawn = new List<GameObject>();
          prefabToSpawn.Add(new GameObject(enemyPrefab1));
          foreach (GameObject prefabToSpawn)
          {
              Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
          } */
        //   GameObject[] enemyPrefabs =
        //     {
        //         enemyPrefab1,
        //         enemyPrefab2,
        //         enemyPrefab3
        //     };

        //   foreach ( in baseEnemies)
        //     {
        //         Instantiate(enemyPrefabs[], transform.position, Quaternion.identity);
        //     } 
        if (currentWave == 10 && bossSpawnedThisWave == false && enemiesLeftToSpawn == 1)
        {
            enemiesAlive++;
            GameObject BossSpawner = bossPrefab;
            Instantiate(BossSpawner, spawnPosition, Quaternion.identity);
            bossSpawnedThisWave = true;
        }

        int randomIndex = UnityEngine.Random.Range(0, enemyPrefabs.Length);
        GameObject prefabToSpawn = enemyPrefabs[randomIndex];
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            timeSinceLastSpawn = 0f;
         //   Debug.Log("Spawn Enemy");
        }
    


    private int EnemiesPerWave()
    {
       // Debug.Log("EnemiesPerWave");
        return (baseEnemies + (currentWave * difficultyScaling));
    }
}
