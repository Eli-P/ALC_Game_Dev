using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30;
    private PlayerController PlayerControllerscript;
    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerscript = GameObject.Find("player").GetComponent < PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControllerscript.GameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}
