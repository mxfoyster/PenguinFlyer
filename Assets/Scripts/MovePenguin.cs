using UnityEngine;
using UnityEngine.UI;

public class MovePenguin : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigidBody;
    public float movementFwdMultiplier, movementUpMultiplier;
    public float rotationMultiplier;
    public Text camText;
    Vector3 sphere_EulerAngleVelocity;
    private Camera mainCamera;

    private int cameraPositionIndex;

    private float turn, climb, move; //directions for movement
    private Animation animPenguin;


    private void Awake()
    {
        mainCamera = Camera.main; //for efficiency, we call it here once and store it..
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        animPenguin = this.GetComponent<Animation>();
        movementFwdMultiplier = 2f;
        movementUpMultiplier = 0.4f;
        rotationMultiplier = 0.8f;
   
        //rotation speed
        sphere_EulerAngleVelocity = new Vector3(0, -100, 0);

        cameraPositionIndex = 1;
        GameManager.Instance.gameRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
            ToggleCameraView();
        
        
        // We get our ionput here so we can't miss a key but we do movement in FixedUpdato
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
            Vector3 newPosition = Vector3.up * (climb * movementUpMultiplier);
            newPosition += Vector3.forward * (move * movementFwdMultiplier);
           

            //update the position
            rigidBody.position = rigidBody.transform.TransformPoint(newPosition);

            //this.gameObject.
        }
    }


    private void ToggleCameraView()
    {
        cameraPositionIndex ++;

        switch (cameraPositionIndex) 
        { 
            case 1:
                mainCamera.transform.Rotate(0, -90, 0);
                mainCamera.transform.Translate(Vector3.right * 15);
                mainCamera.transform.Translate(Vector3.back * 20);
                camText.text = "F1: HELP/PAUSE \nCamview: Behind";

                break;
            case 2:
                mainCamera.transform.Translate(Vector3.forward * 25);
                camText.text = "F1: HELP/PAUSE \nCamview: In Front";

                break;
            case 3:
                mainCamera.transform.Translate(Vector3.back * 5);
                mainCamera.transform.Translate(Vector3.left * 15);
                mainCamera.transform.Rotate(0,90,0);
                camText.text = "F1: HELP/PAUSE \nCamview: Left";
                cameraPositionIndex = 0;
                break;

            case 4:
                break;
        }

    }

}

