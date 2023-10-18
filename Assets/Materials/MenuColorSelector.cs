using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuColorSelector : MonoBehaviour
{
    public int currentColorIndex = 0;
    public GameObject[] colors;
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        currentColorIndex = PlayerPrefs.GetInt("SelectedColor", 0);
        foreach (GameObject color in colors)
        {
            color.SetActive(false);
        }
        colors[currentColorIndex].SetActive(true);
    }
}
