using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControl : MonoBehaviour
{
    public bool shouldRotate = false;
    private Transform ball;

    public float maxDegree = 30f;
    public float rotationSpeed = 10f;
    public float balaceSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.rotation.eulerAngles.z != 0)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldRotate)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(maxDegree, Vector3.forward), Time.deltaTime * rotationSpeed);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(-maxDegree, Vector3.forward), Time.deltaTime * rotationSpeed);
            }
            else
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * balaceSpeed);
            }
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * balaceSpeed);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GameObject[] PL = GameObject.FindGameObjectsWithTag("Platform");
            foreach (GameObject temp in PL)
            {
                PlatformControl e = temp.GetComponent<PlatformControl>();
                e.shouldRotate = false;
                temp.layer = 7;
            }
            this.gameObject.layer = 0;
            shouldRotate = true;
            ball = collision.gameObject.GetComponent<Transform>();
        }
    }
}
