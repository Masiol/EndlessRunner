using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuExitShop : MonoBehaviour
{

    // Update is called once per frame
    public void Menu()
    {

        SceneManager.LoadScene("menu");
    }
    public void Shop()
    {

        SceneManager.LoadScene("Shop");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Started()
    {
        SceneManager.LoadScene("SampleScene");
        SceneManager.LoadScene("SampleScene");
        SceneManager.LoadScene("SampleScene");
    }
}