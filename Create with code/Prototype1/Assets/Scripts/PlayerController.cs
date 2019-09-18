using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float turnSpeed = 5;
    public float horizontalInput;
    public float forwardInput;
    public float maxSpeed;
    public float momentum;
    float momentop = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private float Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // We'll move the vehical forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        // smoother movement
        if (System.Math.Abs(forwardInput) < 0 && momentum > 0)
        {
            momentum /= momentop;
        }
        else
        {
            if (momentum > maxSpeed)
            {
                momentum = maxSpeed;
            }
            else
            {
                if (System.Math.Abs(forwardInput - 1f) < 0)
                {
                    momentum += momentop;
                }
                else
                {
                    if (System.Math.Abs(forwardInput - -1) < 0)
                    {
                        momentum += momentop;
                    }
                }

            }
        }
        
        

    }
}
