using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public Text outputText;

    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    public float swipeRange;
    public float tapRange;


    //////////////
    private bool enableSlowSwipe = false;


    void Update()
    {

        if(!enableSlowSwipe)
        {
            fastSwipe();
        }
        else
        {
            slowSwipe();
        }

        
    }

    public void fastSwipe()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;

            if (!stopTouch)
            {

                if (Distance.x < -swipeRange)
                {
                    outputText.text = "Left";
                    stopTouch = true;
                }
                else if (Distance.x > swipeRange)
                {
                    outputText.text = "Right";
                    stopTouch = true;
                }
                else if (Distance.y > swipeRange)
                {
                    outputText.text = "Up";
                    stopTouch = true;
                }
                else if (Distance.y < -swipeRange)
                {
                    outputText.text = "Down";
                    stopTouch = true;
                }

            }

        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;

            endTouchPosition = Input.GetTouch(0).position;

            Vector2 Distance = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                outputText.text = "Tap";
            }

        }
    }

    public void slowSwipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;

        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;


            Vector2 Distance = endTouchPosition - startTouchPosition;

           
                if (Distance.x < -swipeRange)
                {
                    outputText.text = "Left";
                }
                else if (Distance.x > swipeRange)
                {
                    outputText.text = "Right";
                }
                else if (Distance.y > swipeRange)
                {
                    outputText.text = "Up";
                }
                else if (Distance.y < -swipeRange)
                {
                    outputText.text = "Down";
                }

                if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
                {
                outputText.text = "Tap";
                }

        }

    }

    public void changeMode()
    {
        if (!enableSlowSwipe)
        {
            enableSlowSwipe = true;
        }
        else
        {
            enableSlowSwipe = false;
        }

    }

}

