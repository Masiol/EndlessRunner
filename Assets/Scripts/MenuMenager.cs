using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuMenager : MonoBehaviour
{
    private Animator anim;
    public CanvasGroup menu;
    private bool darker;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(darker)
        {
            menu.alpha += 0.5f * Time.deltaTime;
        }
        if(menu.alpha == 1)
        {
            SceneManager.LoadScene("SampleScene");
            SceneManager.LoadScene("SampleScene");
            SceneManager.LoadScene("SampleScene");
        }
    }
    public void GetStart()
    {
        Invoke("GetDarker", 1f);
    }
    void GetDarker()
    {
        darker = true;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
