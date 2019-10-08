using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    public float horizontalInput;
    public float gravity;
    public float Jump;
    public float boostK;
    public int boost;
    public float boostf = 5.0f;
    private float non;
    public int charge;
    public Rigidbody rb;
    public float momentum;
    public int takeoffSpd = 100;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        Jump = Input.GetAxis("Jump");
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        boostK = Input.GetAxis("Fire1");
        if (boostf < 0)
        {
            charge = 0;
        }
        if (boostf >= 20f)
        {
            charge = 1;
        }
        // move the plane forward at a constant rate
        if (boostK > 0 && boostf > non && charge == 1)
        {
            if (charge == 1)
            {
                if (boostf < 0)
                {
                    charge = 0;
                }
                else
                {
                    boostf -= 0.1f;
                    boost = 2;
                }
            }


        }
        else
        {
            boost = 1;

            if (boostf > 20)
            {
                boostf = 20f;
            }
            else
            {
                boostf += 0.1f;
            }

            if (boostf >= 20f)
            {
                charge = 1;
            }
        }
        transform.Translate(Vector3.forward * speed / 100 * boost * Jump);
        transform.Rotate(Vector3.forward * horizontalInput * -1);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);
        momentum = 1 * speed / 1000;
        if (Jump == 1.0f)
        {
            rb.useGravity = false;
        }
        if (Jump <= 0.5f)
        {
            rb.useGravity = true;
        }

    }
}
