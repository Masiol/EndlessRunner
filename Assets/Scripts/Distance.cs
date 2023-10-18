using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Distance : MonoBehaviour
{
    private GameObject player;
    public static int distance;

    public TextMeshProUGUI distanceText;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Mathf.RoundToInt(player.transform.position.z);
        distanceText.text = distance.ToString() + "m";
       
    }
}
