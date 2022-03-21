using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    private Camera mainCamera;
    private int cameraPositionIndex;
    [SerializeField]private Text camText;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main; //for efficiency, we call it here once and store it..
        cameraPositionIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
            ChangeCameraView();
    }
    
    /// <summary>
    /// Switches camera position
    /// Called by our appropriate GetkeyDown()
    /// </summary>
    private void ChangeCameraView()
    {
        cameraPositionIndex++;

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
                mainCamera.transform.Rotate(0, 90, 0);
                camText.text = "F1: HELP/PAUSE \nCamview: Left";
                cameraPositionIndex = 0;
                break;

            case 4:
                break;
        }

    }
}
