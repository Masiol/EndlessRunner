using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArmorSelector : MonoBehaviour
{
    public int currentModel;
    public GameObject[] Colorss;

    void Start()
    {
        currentModel = PlayerPrefs.GetInt("SelectedColor", 0);
        foreach (GameObject armors in Colorss)
            armors.SetActive(false);

        Colorss[currentModel].SetActive(true);
    }
}
