using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public bool fly;
    private GameObject targ;

    void Start()
    {
        fly = false;
        targ = GameObject.FindWithTag("target");

    }
    void Update()
    {
        targ = GameObject.FindWithTag("target");

        if (fly)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, targ.transform.position, .03f);
            this.transform.localScale -= new Vector3(1.5f, 1.5f, 1.5f) * Time.deltaTime * 3;
            StartCoroutine(DestroyRubins());
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fly = true;
        }
    }
    IEnumerator DestroyRubins()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(this);
    }
   
}
