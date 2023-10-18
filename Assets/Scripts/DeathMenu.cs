using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathMenu : MonoBehaviour
{
    public CanvasGroup deathmenu;
    public CanvasGroup UI;

    void Start()
    {
        UI.alpha = 1;
        deathmenu.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Movement.death)
        {
            UI.alpha = 0;
            deathmenu.alpha += 0.3f * Time.deltaTime;
        }
    }
}
