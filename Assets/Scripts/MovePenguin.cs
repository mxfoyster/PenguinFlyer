using UnityEngine;
using UnityEngine.UI;

public class MovePenguin : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigidBody;
    public float movementFwdMultiplier, movementUpMultiplier;
    public float rotationMultiplier;
   
    Vector3 sphere_EulerAngleVelocity;
  
    private float turn, climb, move; //directions for movement
    private Animation animPenguin;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        animPenguin = this.GetComponent<Animation>();
        movementFwdMultiplier = 400f;
        movementUpMultiplier = 50f;
        rotationMultiplier = 0.8f;
        
        sphere_EulerAngleVelocity = new Vector3(0, -100, 0);    //rotation speed   
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
        if (move != 0 || climb != 0) animPenguin.Play("run");
        else animPenguin.Play("idle");
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.gameRunning)
        {
            //rotate
            sphere_EulerAngleVelocity.y += (turn * rotationMultiplier);
            Quaternion deltaRotation = Quaternion.Euler(sphere_EulerAngleVelocity);
            rigidBody.MoveRotation(deltaRotation);

            // Up / Down & Forward / Backward vectors 
            rigidBody.AddRelativeForce(new Vector3(0, climb * movementUpMultiplier, move * movementFwdMultiplier));
        }
    }
}

