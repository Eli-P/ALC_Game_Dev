using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    public GameObject spawner;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Game Over!");
        Destroy(gameObject);
        Destroy(other.gameObject);
        
    }

}
