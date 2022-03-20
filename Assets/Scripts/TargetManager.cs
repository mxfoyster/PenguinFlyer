using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{

    List<GameObject> targets;
    public GameObject targetMaster;
    private int numberOfTargets;
   // public Text scoreText;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        numberOfTargets = 4;
        
        targets = new List<GameObject>();

        for (int i = 0; i < numberOfTargets; i++)
        {
            GameObject target = GameObject.Instantiate(targetMaster); //create it
            SetPosition(target);
            targets.Add(target);
        }
    }

    private void SetPosition(GameObject thisTarget)
    {
        Transform targetTransform = thisTarget.GetComponent<Transform>(); //get a handle
        targetTransform.position = GameManager.Instance.TargetVector(targetTransform); //set to our randomised vector
    }

}
