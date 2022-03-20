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
    

    
    /// <summary>
    /// Gives me a random position for my targets
    /// </summary>
    /// <returns>Random Vector 3 x(-400 to 400), y (18 - 70), z (-400 - 400)</returns>
    public Vector3 TargetVector(Transform thisTransform)
    {
        Vector3 v3 = thisTransform.position; ;
        float x = Random.Range(-400f, 400f); // set random pos x
        float z = Random.Range(-400f, 400f); //set random pos z
        float y = Random.Range(18f, 70f);
        v3.x = x;
        v3.z = z;
        v3.y = y;
        return v3;
    }
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        audioManager.unmuteSound = false;
    }


}
