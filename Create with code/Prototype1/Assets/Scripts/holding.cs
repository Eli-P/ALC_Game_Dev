using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holding : MonoBehaviour
{
    public float speed = 20f;
    public float turnSpeed = 5;
    public float horizontalInput;
    public float forwardInput;
    public float maxSpeed;
    public float momentum;
    private readonly float momentop = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // We'll move the vehical forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
