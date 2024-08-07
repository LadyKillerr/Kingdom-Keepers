using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] bool isSpawn = true;
    [SerializeField] GameObject enemyToSpawn;
    [SerializeField] GameObject startingWaypoint;
    [SerializeField] float spawnDelay = 2f;

    [SerializeField] int poolSize = 5;
    [SerializeField] GameObject[] pool;

    void Awake()
    {
        StartCoroutine(StartPooling());



    }

    void Start()
    {
        //khi bdau game thì spawnEnemy
        StartCoroutine(SpawnEnemy());
    }

    void Update()
    {

    }

    IEnumerator StartPooling()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(enemyToSpawn, transform);

            pool[i].SetActive(false);

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectsInPool();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void EnableObjectsInPool()
    {
        for (int iterator = 0; iterator < pool.Length; iterator++)
        {
            if (pool[iterator].activeInHierarchy == false)
            {
                pool[iterator].SetActive(true);
                return;
            }
        }
    }
}
