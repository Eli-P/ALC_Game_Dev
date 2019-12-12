using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject preFab;
    private float spawnRange = 9;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        spawnEnemyWave(3);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<>().Length;
        if (enemyCount == 0) { spawnEnemyWave(1); }
    }
    private void spawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(preFab, generateSpawnPosition(), preFab.transform.rotation);
        }
    }

    private Vector3 generateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
