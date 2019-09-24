using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float verticalInput;
    private int boost;
    public float boostF = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        if (verticalInput < 0 && boostF > 0.0)
        {
            boost = 2;
            //boostF -= 0.1;
        }
        else
        {
            boost = 1;
            //boostF += 0.1;
        }
        transform.Rotate(Vector3.forward * Time.deltaTime * 700 * boost);
    }
}
