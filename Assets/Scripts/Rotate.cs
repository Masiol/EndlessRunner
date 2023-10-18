using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float rotationSpeed = 70f;

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate(new Vector3(0,rotationSpeed, 0) * Time.deltaTime);
        this.transform.eulerAngles = new Vector3(68,this.transform.eulerAngles.y, 155);
        
    }
 
}