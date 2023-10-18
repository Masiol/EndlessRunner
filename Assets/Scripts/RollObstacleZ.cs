using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollObstacleZ : MonoBehaviour
{
    private float minusZ = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 0f, minusZ), 3 * Time.deltaTime);
    }
}
