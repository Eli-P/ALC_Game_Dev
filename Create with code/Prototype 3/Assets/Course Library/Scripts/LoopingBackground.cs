using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    private Vector3 startpos;
    private float repeatWidth;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startpos.x - repeatWidth && playerControllerScript.GameOver == false)
        {
            transform.position = startpos;
        }

    }
}
