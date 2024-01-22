using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject obstacle;
    public float maxX = 5;
    public float minX = -5;
    public float maxY = 5;
    public float minY = -5;
    public float timeDiff = 10f;
    private float spawnTime = 0f;

    public GameObject ball;
    public Vector3 offset = new Vector3(0, 8, 0);

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
        transform.position = ball.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeDiff;
        }

        transform.position = ball.transform.position + offset;
    }

    void Spawn()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        Instantiate(obstacle, transform.position + new Vector3(x, y, 0), transform.rotation);
    }
}
