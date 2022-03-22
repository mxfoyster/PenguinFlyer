using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScript : MonoBehaviour
{
    
   /// <summary>
   /// Our collider for triggering walk mode
   /// </summary>
    private void OnCollisionEnter()
    {
        GameManager.Instance.walkMode = true;

    }
}
