using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelector : MonoBehaviour
{
    public int currentColorIndex = 0;
    public GameObject[] colors;
    public Material Material0;
    public Material Material1;
    public Material Material2;
    public Material Material3;
    public Material Material4;
    void Start()
    {
        GameObject g = GameObject.Find("male.007_Circle.001_male.007_Circle.004mesh.001");
        GameObject h = GameObject.Find("male.007_Circle.002_male.007_Circle.004mesh.002");
        GameObject j = GameObject.Find("male.007_Circle.003_male.007_Circle.004mesh.005");
        GameObject k = GameObject.Find("male.007_Circle.005_male.007_Circle.004mesh.004");
        //PlayerPrefs.DeleteAll();
        currentColorIndex = PlayerPrefs.GetInt("SelectedColor", 0);
        if (PlayerPrefs.GetInt("SelectedColor") == 0)
        {
            g.GetComponent<SkinnedMeshRenderer>().material = Material0;
            h.GetComponent<SkinnedMeshRenderer>().material = Material0;
            j.GetComponent<SkinnedMeshRenderer>().material = Material0;
            k.GetComponent<SkinnedMeshRenderer>().material = Material0;

        }
        if (PlayerPrefs.GetInt("SelectedColor") == 1)
        {
            g.GetComponent<SkinnedMeshRenderer>().material = Material1;
            h.GetComponent<SkinnedMeshRenderer>().material = Material1;
            j.GetComponent<SkinnedMeshRenderer>().material = Material1;
            k.GetComponent<SkinnedMeshRenderer>().material = Material1;
        }
        if (PlayerPrefs.GetInt("SelectedColor") == 2)
        {
            g.GetComponent<SkinnedMeshRenderer>().material = Material2;
            h.GetComponent<SkinnedMeshRenderer>().material = Material2;
            j.GetComponent<SkinnedMeshRenderer>().material = Material2;
            k.GetComponent<SkinnedMeshRenderer>().material = Material2;
        }
        if (PlayerPrefs.GetInt("SelectedColor") == 3)
        {
            g.GetComponent<SkinnedMeshRenderer>().material = Material3;
            h.GetComponent<SkinnedMeshRenderer>().material = Material3;
            j.GetComponent<SkinnedMeshRenderer>().material = Material3;
            k.GetComponent<SkinnedMeshRenderer>().material = Material3;
        }
        if (PlayerPrefs.GetInt("SelectedColor") == 4)
        {
            g.GetComponent<SkinnedMeshRenderer>().material = Material4;
            h.GetComponent<SkinnedMeshRenderer>().material = Material4;
            j.GetComponent<SkinnedMeshRenderer>().material = Material4;
            k.GetComponent<SkinnedMeshRenderer>().material = Material4;
        }
    }
}