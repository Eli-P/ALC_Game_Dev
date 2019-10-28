using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float spdelay;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && spdelay > 10)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            spdelay = 0;
        }
        else
        {
            spdelay += .1f;
        }
    }
}
