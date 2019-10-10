using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    public GameObject Player;
    public float speed;
    public float rotate;
    public float targetDist;
    public float firingDist;
    public bool fire;
    public float life=20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetDist = Vector3.Distance(Player.transform.position, transform.position);
        if (targetDist < firingDist)
        {
            //transform.Translate(Vector3.forward);
            
            transform.LookAt(Player.transform.position);

            fire = true;
        }
    }
}
