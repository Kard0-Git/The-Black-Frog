using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{


    public float countdown;
    public float tickrate;

    public GameObject Enemy;

    [SerializeField] private List<GameObject> EnemyCount;

    public int EnemySpawnLimit;

    public Transform EnemyAmount;

    bool StopEnemySpawn = false;

    GameTextHandler gameTextHandler;
    CheckEnemyAmount CheckEnemyAmount;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        countdown = tickrate;
        gameTextHandler = FindAnyObjectByType<GameTextHandler>();
        CheckEnemyAmount = FindAnyObjectByType<CheckEnemyAmount>();
    }

    // Update is called once per frame
    void Update()
    {
       spawnEnemies();
       StopSpawningEnemies();
    
    }


    void spawnEnemies()
    {

        if (!StopEnemySpawn)
        {
            countdown -= Time.deltaTime;

        if(countdown <= 0)
        {
            Instantiate(Enemy,transform.position,Quaternion.identity,EnemyAmount);
            countdown = tickrate;
            EnemyCount.Add(Enemy);
            gameTextHandler.CountEnemies();

          


        }

         



        }
        
    
    }

    void StopSpawningEnemies()
    {
        // stop spawning enemies if the limit has been breached
        if(EnemyCount.Count >= EnemySpawnLimit)
        {
            StopEnemySpawn = true;

             if(EnemyAmount.childCount <= 0)
                {
                CheckEnemyAmount.CheckEnemyCount();
                }
        }
    }

    

  


}
