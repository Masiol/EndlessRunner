using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShoes : MonoBehaviour
{
    private float rotationSpeed = 70f;

    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate(new Vector3(0,0,rotationSpeed) * Time.deltaTime);
        //this.transform.eulerAngles = new Vector3(-90, this.transform.eulerAngles.y, 90);

    }

}