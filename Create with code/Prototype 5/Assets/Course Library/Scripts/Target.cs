using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Target : MonoBehaviour
{
    private Rigidbody targetrb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem boom;
    public TextMeshProUGUI gameOver;
    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetrb = GetComponent<Rigidbody>();
        targetrb.AddForce(RandomForce(), ForceMode.Impulse);
        targetrb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    Vector3 RandomForce() { return Vector3.up * Random.Range(minSpeed, maxSpeed); }
    float RandomTorque() { return Random.Range(-maxTorque, maxTorque); }
    Vector3 RandomSpawnRange() { return new Vector3(Random.Range(-xRange, xRange), ySpawnPos); }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(boom, transform.position, boom.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
            gameOver.gameObject.SetActive(true);
        }
        Destroy(gameObject);
    }
}
