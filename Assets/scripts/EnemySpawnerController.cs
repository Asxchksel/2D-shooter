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
    float timeBetweenPickups = 15.0f;

    GameObject player;
 
    void Update()
    {
        float randomNumber = Random.Range(0, 10);  

        enemySpawnTimer += Time.deltaTime;
        pickupSpawnTimer += Time.deltaTime;

        if (enemySpawnTimer > timeBetweenEnemies){
            Instantiate(EnemyPrefab);
            enemySpawnTimer = 0;
        }

        if(pickupSpawnTimer > timeBetweenPickups && randomNumber < 5 && player.GetComponent<ShipController>().currentHp != 100){
            Instantiate(HealthPickupPrefab);
            pickupSpawnTimer = 0;
            }

        if(pickupSpawnTimer > timeBetweenPickups && randomNumber >= 5){
            Instantiate(LaserBeamPickup);
            pickupSpawnTimer = 0;    
        }
       
    }
}
