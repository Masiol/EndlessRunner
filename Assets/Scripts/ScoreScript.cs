using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI rekord;
    public TextMeshProUGUI highscore;
    private float scoreS;
    void Start()
    {
        highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreS = (Distance.distance * 3.14f + 8 / 3.8f); ;
        int myScore = Mathf.RoundToInt(scoreS);
        score.text = myScore.ToString()+ "";
        //PlayerPrefs.DeleteKey("HighScore");
        if(myScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", myScore);
            highscore.text = myScore.ToString();
            rekord.gameObject.SetActive(true);
            
            
        }
        if (myScore < PlayerPrefs.GetInt("HighScore", 0))
        {
            rekord.gameObject.SetActive(false);

        }
    }
}
