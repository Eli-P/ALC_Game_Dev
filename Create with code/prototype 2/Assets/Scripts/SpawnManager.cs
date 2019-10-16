using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animals;
    public float XRange = 15f;
    public int counterF;
    public int counterM;
    public int counterD;
    public int counterC;
    private float startdelay = 2f;
    private float interval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startdelay, interval);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomAnimal();
        }
    }
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animals.Length);
        int spawnPos = 20;
        Vector3 xRange = new Vector3(Random.Range(-XRange, XRange), 0, spawnPos);

        Instantiate(animals[animalIndex], xRange, animals[animalIndex].transform.rotation);
        if (animalIndex == 0)
        {
            counterC++;
        }
        if (animalIndex == 1)
        {
            counterF++;
        }
        if (animalIndex == 2)
        {
            counterM++;
        }
        if (animalIndex == 3)
        {
            counterD++;
        }
    }
}
