using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollctableRubins : MonoBehaviour
{
    public List<float> RubinX;
    public List<float> RubinY;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public float GetLane()
    {
        if (RubinX == null || RubinX.Count < 1)
        {
            return -1f;
        }
        return RubinX[Random.Range(0, RubinX.Count)];
    }
    public float GetJump()
    {
        if (RubinY == null || RubinY.Count < 1)
        {
            return -1f;
        }
        return RubinY[Random.Range(0, RubinY.Count)];
    }

}