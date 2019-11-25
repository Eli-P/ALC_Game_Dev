using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public bool isOnGround = true;
    public bool GameOver;
    public float gravity;
    public float jump;
    private Animator player;
    //public ParticleSystem boom;
    public ParticleSystem dirt;
    public GameObject obstacle;
    private Vector3 spawnPos = new Vector3(-2.042927f, 0, 0);
    public AudioClip Jump;
    public AudioClip boom;
    private AudioSource Player;

    public void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        player = GetComponent<Animator>();
        Physics.gravity *= gravity;
        Player = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !GameOver)
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            isOnGround = false;
            player.SetTrigger("Jump_trig");
            dirt.Stop();
            Player.PlayOneShot(Jump, 1.0f);
        }
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirt.Play();
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            //boom.Play();
            Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
            Debug.Log("Game Over");
            player.SetBool("Death_b", true);
            player.SetInteger("DeathType_int", 1);
            GameOver = true;
            dirt.Stop();
            Player.PlayOneShot(boom, 1.0f);
            //boom.Play();
        }

    }
}
