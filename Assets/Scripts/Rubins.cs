using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Rubins : MonoBehaviour
{
    public TextMeshProUGUI rubins;
    public TextMeshProUGUI rubinsEndGame;
    public int currentRubins = 0;
    public int CollectedRubins = 0;

    void Start()
    {
        rubinsEndGame = GameObject.Find("RubinsEndGame").GetComponent<TextMeshProUGUI>();
        rubins = GameObject.Find("rubins").GetComponent<TextMeshProUGUI>();
        //PlayerPrefs.DeleteAll();
        Application.targetFrameRate = 60;

        if (PlayerPrefs.HasKey("Rubins"))
        {
            currentRubins = PlayerPrefs.GetInt("Rubins");
            
        }
        rubins.text = "" + currentRubins;
        rubinsEndGame.text = "" + CollectedRubins;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Rubins")
        {
            currentRubins += 1;
            CollectedRubins +=1;
            PlayerPrefs.SetInt("Rubins", currentRubins);
            rubins.text = "" +currentRubins;
            rubinsEndGame.text = "" + CollectedRubins;
        }
    }
}
