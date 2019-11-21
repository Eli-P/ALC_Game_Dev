using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public bool isOnGround = true;
    public void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * 1000);
            isOnGround = false;
        }
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        isOnGround = true;
    }
}
