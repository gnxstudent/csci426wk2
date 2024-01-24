using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject obstacle;
    public float maxX = 15;
    public float minX = -15;
    private float maxY = 0;
    private float minY = 0;
    public float timeDiff = 10f;
    private float spawnTime = 0f;

    GameObject ball;
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
    }

    void Spawn()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        Instantiate(obstacle, transform.position + new Vector3(x, 7, 0), transform.rotation);
    }
}
