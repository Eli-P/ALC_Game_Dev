using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject preFab;
    private float spawnRange = 9;

    // Start is called before the first frame update
    void Start()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        Instantiate(preFab, new Vector3(0, 0, 6), preFab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3
}
