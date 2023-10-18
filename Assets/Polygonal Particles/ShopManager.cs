using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopManager : MonoBehaviour
{
    public int currentColorIndex = 0;
    public GameObject[] colormodels;

    public ColorBluePrint[] colorblueprint;
    public Button buyBatton;

    void Start()
    {
        foreach(ColorBluePrint col in colorblueprint)
        {
            if (col.price == 0)
                col.isUnlocked = true;
            else
                col.isUnlocked = PlayerPrefs.GetInt(col.name, 0) ==0 ? false : true;
        }
        currentColorIndex = PlayerPrefs.GetInt("SelectedColor", 0);
        foreach (GameObject color in colormodels)
        {
            color.SetActive(false);
        }
        colormodels[currentColorIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }
    public void ChangeNext()
    {
        colormodels[currentColorIndex].SetActive(false);

        currentColorIndex++;
        if (currentColorIndex == colormodels.Length)
        {
            currentColorIndex = 0;
        }

        colormodels[currentColorIndex].SetActive(true);
        ColorBluePrint c = colorblueprint[currentColorIndex];
        if (!c.isUnlocked)
            return;
        PlayerPrefs.SetInt("SelectedColor", currentColorIndex);
    }
    public void ChangePrevious()
    {
        colormodels[currentColorIndex].SetActive(false);

        currentColorIndex--;
        if (currentColorIndex == -1)
        {
            currentColorIndex = colormodels.Length -1;
        }

        colormodels[currentColorIndex].SetActive(true);
        ColorBluePrint c = colorblueprint[currentColorIndex];
        if (!c.isUnlocked)
            return;
        PlayerPrefs.SetInt("SelectedColor", currentColorIndex);
    }
    private void UpdateUI()
    {
        ColorBluePrint c = colorblueprint[currentColorIndex];
        if(c.isUnlocked)
        {
            buyBatton.gameObject.SetActive(false);
        }
        else
        {
            buyBatton.gameObject.SetActive(true);
            buyBatton.GetComponentInChildren<TextMeshProUGUI>().text = c.price.ToString();
            if(c.price <= PlayerPrefs.GetInt("Rubins",0))
            {
                buyBatton.interactable = true;
            }
            else
            {
                buyBatton.interactable = false;
            }
        }
    }
    public void UnlockCar()
    {
        ColorBluePrint c = colorblueprint[currentColorIndex];

        PlayerPrefs.SetInt(c.name,1);
        PlayerPrefs.SetInt("SelectedColor", currentColorIndex);
        c.isUnlocked = true;
        PlayerPrefs.SetInt("Rubins", PlayerPrefs.GetInt("Rubins", 0) - c.price);
    }
}
