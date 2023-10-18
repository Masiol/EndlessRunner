using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollObstacle : MonoBehaviour
{
    private float rotationSpeed = -90f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate(new Vector3(rotationSpeed, 0, 0) * Time.deltaTime);

    }
}
