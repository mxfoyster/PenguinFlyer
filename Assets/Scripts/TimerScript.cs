using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    private float _timeRemaining;

    [SerializeField]
    private Text timerDisplay;
    private bool timerOn;
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {

        _timeRemaining = 90;
        timerOn = true; //for now
        isPaused = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        //Normal funning game conditions
        if(timerOn && _timeRemaining>0)
        {
            
            _timeRemaining -= Time.deltaTime;
            string seconds = (_timeRemaining % 60).ToString("00");
            int minutes = Mathf.FloorToInt(_timeRemaining / 60f);
            timerDisplay.text = "Time Remaining. " + minutes + ":" + seconds;
        }

         //check for Pause Toggle
        if (Input.GetKeyDown(KeyCode.F2)) PauseGame();
        
        
        if (_timeRemaining <= 0)
        {
            timerDisplay.text = "TIME UP!!! ";
        }
    }

    private void PauseGame()
    {
        if (!isPaused && _timeRemaining > 0)
        {
            isPaused = true;
            timerOn = false;
            timerDisplay.text = "PAUSED";
        }
        else if (_timeRemaining > 0)
        {
            isPaused = false;
            timerOn = true;
        }
    }
}
