using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabLifeTime : MonoBehaviour
{
    public float distance;
    public Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            Destroy(this.gameObject, 2.5f);
        }
    }
    void Update()
    {
        distance = Vector3.Distance(player.position, this.transform.position);

        for (int a = 0; a < transform.childCount; a++)
        {
            if (distance < 40)
            {
                this.transform.GetChild(a).gameObject.SetActive(true);
            }
            if (distance > 40)
            {
                this.transform.GetChild(a).gameObject.SetActive(false);
            }
            if(Movement.death)
            {
                //this.transform.GetChild(a).gameObject.SetActive(false);
            }

        }

    }
}
