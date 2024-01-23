using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    GameObject curr_platform = null;
    Vector3 offset = new Vector3(0f, 3f, -10f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] PLs = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject temp in PLs)
        {
            if (temp.layer == 0)
            {
                curr_platform = temp;
                break;
            }
        }

        this.transform.position = curr_platform.transform.position + offset;
    }
}
