using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RubinsShop : MonoBehaviour
{
    public TextMeshProUGUI rubins;
    public int currentRubins = 0;

    void Start()
    {
        if (PlayerPrefs.HasKey("Rubins"))
        {
            currentRubins = PlayerPrefs.GetInt("Rubins");

        }
        rubins.text = "" + currentRubins;
    }
}
