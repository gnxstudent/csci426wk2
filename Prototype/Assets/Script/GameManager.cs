using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject m_ball;
    // Start is called before the first frame update
    void Start()
    {
        m_ball = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Restart();
        }

        GameObject[] Obstacles = GameObject.FindGameObjectsWithTag("Respawn");
        foreach (GameObject temp in Obstacles)
        {
            if (Vector3.Distance(temp.transform.position, m_ball.transform.position) > 20)
            {
                Destroy(this);
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
