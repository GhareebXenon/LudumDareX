using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject EnemyEntity;
    [SerializeField]
    Transform[] spawnPoint;
    public int enemyCount;
    [SerializeField]
    int maxEnemyNum;

    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    void Update()
    {

    }

    IEnumerator EnemySpawn()
    {
        enemyCount = 0;
        for (enemyCount = 0; enemyCount < maxEnemyNum; enemyCount++)
        {
            Instantiate(EnemyEntity, spawnPoint[Random.Range(0, 5)].position, Quaternion.identity);
            yield return new WaitForSeconds(0.7f);
            if (maxEnemyNum < 100)
                maxEnemyNum += 1;
        }
    }
}
