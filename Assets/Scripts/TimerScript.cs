using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    private float _timeRemaining;

    //UI HUD stuff
    [SerializeField] private Text timerDisplay;
    [SerializeField] private Text EndScoreDisplay;
    
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject helpPanel;

    //Flags
    private bool timerOn;
    private bool isPaused;

    private Coroutine endCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = true;
        ResetGame();
        GameManager.Instance.gameRunning = false;
        timerOn = false;
    }


    /// <summary>
    /// Start button method for start screen
    /// </summary>
    public void OnClickStartButton()
    {
        GameManager.Instance.audioManager.unmuteSound = true; 
        GameManager.Instance.audioManager.BkgSound("play");
        isPaused = false;
        timerOn = true;
        GameManager.Instance.gameRunning = true;
        startPanel.SetActive(false);
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
        if (Input.GetKeyDown(KeyCode.F1)) PauseGame();
        if (Input.GetKeyDown(KeyCode.F12)) OnClickQuitButton();

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
        EndScoreDisplay.text = "You Scored " + GameManager.Instance.myScore + " Points.";
        timerOn = false;
        GameManager.Instance.gameRunning = false;
        gameOverPanel.SetActive(true);
        GameManager.Instance.audioManager.BkgSound("pause");
        endCoroutine = StartCoroutine(GameManager.Instance.audioManager.PlayEndSounds(false, GameManager.Instance.audioManager.unmuteSound));
    }


    /// <summary>
    /// Handler method for Go Again button on Game Over panel
    /// </summary>
    public void onClickReplay()
    {
        GameManager.Instance.audioManager.BkgSound("resume");
        ResetGame();
    }

    /// <summary>
    /// Sets everything to start values either for after welcome screen
    /// Or for "Another Go" on end screen
    /// </summary>
    private void ResetGame()
    {
        gameOverPanel.SetActive(false);
        GameManager.Instance.gameRunning = true;
        GameManager.Instance.myScore = 0;
        GameManager.Instance.scoreText.text = "Score: " + GameManager.Instance.myScore;
        _timeRemaining = 90;  
        timerOn=true;
        GameManager.Instance.audioManager._soundPlayed = false; //reset our coroutine flag
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
    /// Pause Game \ Help screen method
    /// </summary>
    private void PauseGame()
    {
        if (!isPaused && _timeRemaining > 0)
        {
            isPaused = true;
            GameManager.Instance.gameRunning = false;
            timerOn = false;
            timerDisplay.text = "PAUSED";
            GameManager.Instance.audioManager.BkgSound("pause");
            
        }
        else if (_timeRemaining > 0)
        {
            isPaused = false;
            timerOn = true;
            GameManager.Instance.gameRunning = true;
            GameManager.Instance.audioManager.BkgSound("resume");
            
        }
        helpPanel.SetActive(isPaused); //activate panel as necessary
    }
}
