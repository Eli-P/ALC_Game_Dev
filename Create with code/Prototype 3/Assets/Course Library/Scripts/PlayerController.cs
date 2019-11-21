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
    public ParticleSystem boom;
    public ParticleSystem dirt;

    public void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        player = GetComponent<Animator>();
        Physics.gravity *= gravity;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !GameOver)
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            isOnGround = false;
            player.SetTrigger("Jump_trig");
            dirt.Stop();
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
            Debug.Log("Game Over");
            player.SetBool("Death_b", true);
            player.SetInteger("DeathType_int", 1);
            GameOver = true;
            dirt.Stop();
            boom.Play();
        }

    }
}
