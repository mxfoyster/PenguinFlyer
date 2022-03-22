using UnityEngine;
using UnityEngine.UI;

public class MovePenguin : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigidBody;
    public float movementFwdMultiplier, movementUpMultiplier;
    public float rotationMultiplier;
  
    private float turn, climb, move; //directions for movement
    private Animation animPenguin;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        animPenguin = this.GetComponent<Animation>();
        movementFwdMultiplier = 550f;
        movementUpMultiplier = 250f;
        rotationMultiplier = 5f;
        
        GameManager.Instance.gameRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        // We get our input here so we can't miss a key but we do movement in FixedUpdato
        // to ensure it's not proportional to framerate
        turn = Input.GetAxis("Horizontal");
        climb = Input.GetAxis("UpDown");
        move = Input.GetAxis("Vertical");
        
        //flying mode animations
        if (!GameManager.Instance.walkMode)
        {
            if (move != 0 || climb != 0) animPenguin.Play("run");
            else animPenguin.Play("idle");
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.gameRunning)
        {
            //rotate
            rigidBody.AddRelativeTorque(new Vector3(0, turn * rotationMultiplier, 0));            
            
            //Forward / Backward vectors 
            rigidBody.AddRelativeForce(new Vector3(0, 0, move * movementFwdMultiplier));

            //Up / Down
            if (!GameManager.Instance.walkMode) //flying movements
            {
                rigidBody.AddRelativeForce(new Vector3(0, climb * movementUpMultiplier, 0));
            }
            else //walk mode movements
            {
                if (move != 0) animPenguin.Play("walk");
                else animPenguin.Play("idle");
                rigidBody.useGravity = true;
                
                //if we climb, we leave walk mode
                if (climb > 0)
                {
                    rigidBody.useGravity = false;
                    GameManager.Instance.walkMode = false;
                }
            }
        }
    }
}

