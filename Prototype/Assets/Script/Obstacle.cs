using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    GameObject ball = null;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(ball.transform.position, transform.position) > 20 || transform.position.y < -15)
        {
            Destroy(gameObject); 
        }
    }
}
