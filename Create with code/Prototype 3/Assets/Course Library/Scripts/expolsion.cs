using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expolsion : MonoBehaviour
{
    private float colli;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        colli = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        if (player.transform.position.y > .1)
        {
            //Destroy(gameObject);
        }
    }
}
