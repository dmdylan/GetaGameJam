using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] enemySpawners;
    public FloatValue enemyCount;
    public Enemy[] enemyPrefab;


    // Start is called before the first frame update
    void Start()
    {
        AddEnemiesToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemies()
    {
        List<Transform> freeSpawnPoints = new List<Transform>(enemySpawners);
        
       


            int spawnPointIndex = Random.Range(0, enemySpawners.Length);
            Transform position = freeSpawnPoints[spawnPointIndex];
            //use for loop to loop through each enemy in separate enemy list
       
        return;
    }

    private List<Enemy> AddEnemiesToList()
    {
        var currentEnemyCount = 0f; 
        List<Enemy> enemiesToSpawn = new List<Enemy>();

        for(int i = 0; i < enemyCount.Value;)
        {
            var enemy = enemyPrefab[Random.Range(0, enemyPrefab.Length)];
            enemiesToSpawn.Add(enemy);
            currentEnemyCount += enemy.profile.enemyValue;
            foreach (Enemy x in enemiesToSpawn)
                print(x);
        }

        return enemiesToSpawn;
    }

    //Separate method that runs through random enemies to get count
    //Adds those enemies to a list
    //Then call that method and instantiate enemies
}
