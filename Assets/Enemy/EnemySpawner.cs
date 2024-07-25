using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyToSpawn;
    [SerializeField] float spawnDelay = 2f;
    [SerializeField] GameObject startingWaypoint;


    void Start()
    {
        StartCoroutine(SpawnEnemyAfterDelay(spawnDelay));
    }

    void Update()
    {
        
    }

    IEnumerator SpawnEnemyAfterDelay(float delay)
    {
        while (true)
        {
            Vector3 position = startingWaypoint.transform.position;
            Instantiate(enemyToSpawn, position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
    }
}
