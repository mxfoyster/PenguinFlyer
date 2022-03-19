using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// My Singleton Score manager to keep track of all the scores.
/// </summary>
public class GameManager : MonoBehaviour 
{
    public static GameManager Instance { get; private set; }
    public AudioManager audioManager;

    public Text scoreText;
    public int myScore;
    public bool gameRunning;

    private void Awake()
    {
        Instance = this;
    }


}
