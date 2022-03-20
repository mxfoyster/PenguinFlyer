using UnityEngine;



public class TargetHitScript : MonoBehaviour
{
   

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.myScore += 10;
        GameManager.Instance.scoreText.text = "Score: " + GameManager.Instance.myScore;
        ResetTarget();
        GameManager.Instance.audioManager.PlayHit();
    }

   
    private void ResetTarget()
    {
        Transform targetTransform = this.gameObject.transform; //get a handle
        targetTransform.position = GameManager.Instance.TargetVector(targetTransform);//set to our randomised vector
    }
   
}
