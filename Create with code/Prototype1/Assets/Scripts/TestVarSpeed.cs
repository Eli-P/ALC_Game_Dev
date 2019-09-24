using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVarSpeed : MonoBehaviour
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
        transform.Translate(Vector3.forward * Time.deltaTime * speed * momentum);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        if (forwardInput < 0 && momentum > 0)
        {
            momentum /= 10;
        }
        else
        {
            if (momentum > maxSpeed)
            {
                momentum = maxSpeed;
            }
            else
            {
                if (forwardInput > 0)
                {
                    momentum += momentop;
                }
                else
                {
                    if (forwardInput < 0)
                    {
                        momentum -= momentop;
                    }
                }

            }
        }

    }
}
