using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    private float _timeRemaining;

    //UI HUD stuff
    [SerializeField]
    private Text timerDisplay;
    [SerializeField]
    private Text EndScoreDisplay;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    GameObject quitButton;
    [SerializeField]
    GameObject replayButton;
    
    //Flags
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
            GameOver();
           
        }
    }// End of Update()

    /// <summary>
    /// Game Over method
    /// Displays the Game Over panel etc
    /// </summary>
    private void GameOver()
    { 
        timerDisplay.text = "TIME UP!!! ";
        EndScoreDisplay.text = "You Scored " + GameManager.Instance.myScore + "Points.";
        timerOn = false;
        GameManager.Instance.gameRunning = false;
        gameOverPanel.SetActive(true);
    }


    /// <summary>
    /// Handler method for Go Again button on Game Over panel
    /// </summary>
    public void onClickReplay()
    {
        gameOverPanel.SetActive(false);
        GameManager.Instance.gameRunning = true;
        GameManager.Instance.myScore = 0;
        GameManager.Instance.scoreText.text = "Score: " + GameManager.Instance.myScore;
        _timeRemaining = 90;  
        timerOn=true;
    }

    /// <summary>
    /// Handler method for Quit button on Game Over panel
    /// </summary>
    public void OnClickQuitButton()
    {
    #if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
    }


    /// <summary>
    /// Pause Game method
    /// </summary>
    private void PauseGame()
    {
        if (!isPaused && _timeRemaining > 0)
        {
            isPaused = true;
            GameManager.Instance.gameRunning = false;
            timerOn = false;
            timerDisplay.text = "PAUSED";
        }
        else if (_timeRemaining > 0)
        {
            isPaused = false;
            timerOn = true;
            GameManager.Instance.gameRunning = true;
        }
    }
}
