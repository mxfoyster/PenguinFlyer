using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

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
        Vector3 v3 = targetTransform.position;
        float x = Random.Range(-400f, 400f); // set random pos x
        float z = Random.Range(-400f, 400f); //set random pos z
        float y = Random.Range(10f, 50f);
        v3.x = x;
        v3.z = z;
        v3.y = y;
        targetTransform.position = v3;
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
