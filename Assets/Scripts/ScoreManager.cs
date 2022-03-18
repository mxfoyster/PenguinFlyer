using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// My Singleton Score manager to keep track of all the scores.
/// </summary>
public class ScoreManager : MonoBehaviour 
{
    public static ScoreManager Instance { get; private set; }
 
    public Text scoreText;
    public int myScore;

    private void Awake()
    {
        Instance = this;
    }


}
