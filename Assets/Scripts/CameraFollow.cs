using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform Target;
    private Vector3 Offset;
    private float y;
    public float speedFollow = 5f;
    void Start()
    {
        Offset = transform.position;
        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 followPos = Target.position + Offset;
        RaycastHit hit;
        if (Physics.Raycast(Target.position, Vector3.down, out hit, 2.5f))
           y = Mathf.Lerp(y, hit.point.y, Time.deltaTime * speedFollow);
        else
        
            y = Mathf.Lerp(y, Target.position.y, Time.deltaTime * speedFollow);
            followPos.y = Offset.y + y;
            transform.position = followPos;
  
    }
}
