using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] enemySpawners = null;
    public FloatValue enemyCount;
    public IntValue enemiesRemaining;
    public FloatValue propCount;
    public Enemy[] enemyPrefab = null;
    public Props[] propsPrefabs = null;
    private List<Transform> freeSpawnPoints; 

    void Awake()
    {
        freeSpawnPoints = new List<Transform>(enemySpawners);
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    //Create list of open spawn points and a list of enemies from other method
    //Run through list of enemies and spawn them at random open location
    void SpawnEnemies()
    {
        List<Enemy> enemies = AddEnemiesToList();
        List<Props> objects = AddObjectsToList();

        for (int i = 0; i < enemies.Count; i++)
        {
            int spawnPointIndex = Random.Range(0, freeSpawnPoints.Count);
            Transform position = freeSpawnPoints[spawnPointIndex];
            Instantiate(enemies[i], position.position, position.rotation);
            freeSpawnPoints.RemoveAt(spawnPointIndex);
        }

        for (int j = 0; j < objects.Count; j++)
        {
            int spawnPointIndex = Random.Range(0, freeSpawnPoints.Count);
            Transform position = freeSpawnPoints[spawnPointIndex];
            Instantiate(objects[j], position.position, Random.rotation);
            freeSpawnPoints.RemoveAt(spawnPointIndex);
        }

        return;
    }

    private List<Props> AddObjectsToList()
    {
        List<Props> propsToSpawn = new List<Props>();

        for(int i = 0; i < propCount.Value;)
        {
            var prop = propsPrefabs[Random.Range(0, propsPrefabs.Length)];
            if(prop.profile.propValue + i > propCount.Value)
            {
                prop = propsPrefabs[Random.Range(0, propsPrefabs.Length)];
            }
            else
            {
                i += prop.profile.propValue;
                propsToSpawn.Add(prop);
            }
        }

        return propsToSpawn;
    }

    //Separate method that runs through random enemies to get count
    //Adds those enemies to a list
    //Then call that method and instantiate enemies
    private List<Enemy> AddEnemiesToList()
    {
        List<Enemy> enemiesToSpawn = new List<Enemy>();

        for(int i = 0; i < enemyCount.Value;)
        {
            var enemy = enemyPrefab[Random.Range(0, enemyPrefab.Length)];
            if(enemy.profile.enemyValue + i > enemyCount.Value)
            {
                enemy = enemyPrefab[Random.Range(0, enemyPrefab.Length)];
            }
            else
            {
                i += enemy.profile.enemyValue;
                enemiesToSpawn.Add(enemy);
            }
        }

        foreach (Enemy x in enemiesToSpawn)
        {
            enemiesRemaining.Value++;
        }   

        return enemiesToSpawn;
    }

}
