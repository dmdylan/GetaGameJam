using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] enemySpawners = null;
    public FloatValue enemyCount;
    public Enemy[] enemyPrefab = null;


    // Start is called before the first frame update
    void Start()
    { 
        
        SpawnEnemies();

    }

    //Create list of open spawn points and a list of enemies from other method
    //Run through list of enemies and spawn them at random open location
    void SpawnEnemies()
    {
        List<Transform> freeSpawnPoints = new List<Transform>(enemySpawners);
        List<Enemy> enemies = AddEnemiesToList();

        for(int i = 0; i < enemies.Count; i++)
        {
            int spawnPointIndex = Random.Range(0, enemySpawners.Length);
            Transform position = freeSpawnPoints[spawnPointIndex];
            freeSpawnPoints.RemoveAt(spawnPointIndex);
            Instantiate(enemies[i], position.position, position.rotation);           
        }
        
        return;
    }

    //Separate method that runs through random enemies to get count
    //Adds those enemies to a list
    //Then call that method and instantiate enemies
    private List<Enemy> AddEnemiesToList()
    {
        List<Enemy> enemiesToSpawn = new List<Enemy>();
        var currentEnemyCountValue = 0f;

        for(int i = 0; i < enemyCount.Value;)
        {
            var enemy = enemyPrefab[Random.Range(0, enemyPrefab.Length)];
            if(enemy.profile.enemyValue + i > 100)
            {
                enemy = enemyPrefab[Random.Range(0, enemyPrefab.Length)];
            }
            else
            {
                i += enemy.profile.enemyValue;
                currentEnemyCountValue = i;
                enemiesToSpawn.Add(enemy);
            }
        }

        foreach (Enemy x in enemiesToSpawn)
        {
            print(x);
            print(currentEnemyCountValue);
        }   

        return enemiesToSpawn;
    }

}
