using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField] 
    GameObject EnemyPrefab;

    [SerializeField]
    GameObject HealthPickupPrefab;

    [SerializeField]
    GameObject LaserBeamPickup;

    float enemySpawnTimer = 0;

    float pickupSpawnTimer = 0;

    [SerializeField] 
    float timeBetweenEnemies = 1.5f;

    [SerializeField] 
    float timeBetweenPickups = 5.0f;
    
    void Update()
    {
        enemySpawnTimer += Time.deltaTime;
        pickupSpawnTimer += Time.deltaTime;

        if (enemySpawnTimer > timeBetweenEnemies){
            Instantiate(EnemyPrefab);
            enemySpawnTimer = 0;
        }

        if(pickupSpawnTimer > timeBetweenPickups){
            float randomNumber = Random.Range(1, 10);  
                if(randomNumber <= 5){
                    Instantiate(HealthPickupPrefab);
                    pickupSpawnTimer = 0;
                }
                if(randomNumber > 5){
                    Instantiate(LaserBeamPickup);
                    pickupSpawnTimer = 0;
                }
            
        }
       
    }
}
