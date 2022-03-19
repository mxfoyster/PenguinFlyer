using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TargetHitScript : MonoBehaviour
{   
    private void OnTriggerEnter(Collider other)
    {
        //this.gameObject.SetActive(false);
        GameManager.Instance.myScore += 10;
        
        GameManager.Instance.scoreText.text = "Score: " + GameManager.Instance.myScore;
        ResetTarget();
        
    }

    private void ResetTarget()
    {

        Transform targetTransform = this.gameObject.transform; //get a handle
        Vector3 v3 = targetTransform.position;
        float x = Random.Range(-400f, 400f); // set random pos x
        float z = Random.Range(-400f, 400f); //set random pos z
        float y = Random.Range(10f, 50f);
        v3.x = x;
        v3.z = z;
        v3.y = y;
        targetTransform.position = v3;
    }
}
