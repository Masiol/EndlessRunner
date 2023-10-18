using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public CanvasGroup deathmenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reset()
    {
        deathmenu.alpha = 0;
        SceneManager.LoadScene("SampleScene");
        SceneManager.LoadScene("SampleScene");
        SceneManager.LoadScene("SampleScene");
    }
    public void Menu()
    {
        deathmenu.alpha = 0;
        SceneManager.LoadScene("menu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
