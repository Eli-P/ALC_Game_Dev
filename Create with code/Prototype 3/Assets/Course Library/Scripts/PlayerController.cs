using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public ParticleSystem explosion;
    public float jumpForce;
    private Vector3 spawnPos = new Vector3(-2.042927f, 0, 0);
    public float gravityMod;
    public bool isOnGround = true;
    public bool GameOver;
    private Animator playerAnim;
    public GameObject obstacle;
    public GameObject dirt;
    private float colli;
    private bool die = true;
    public bool dirty;
    public bool dirts;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        colli = transform.position.x;
        Physics.gravity *= gravityMod;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !GameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            Destroy(dirt);
            dirty = true;
            
        }
        if(transform.position.y < .01)
        {
            isOnGround = true;
            playerAnim.SetBool("Jump_b", false);
            if (dirty)
            {
                dirts = true;
                dirty = false;
            }
            if (dirts)
            {
                Instantiate(dirt, spawnPos, obstacle.transform.rotation);
                dirts = false;
            }
        }
        else
        {
            isOnGround = false;
            playerAnim.SetBool("Jump_b", true);
        }
        if(transform.position.x - colli > .1 || transform.position.x - colli < -.1)
        {
            Debug.Log("GameOver!");
            GameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            if (die)
            {
                Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
                die = false;
            }
            explosion.Play();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            isOnGround = true;
        }
        isOnGround = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            isOnGround = true;
        }
    }
}
