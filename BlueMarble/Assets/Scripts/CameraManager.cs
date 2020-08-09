using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject miniGameCamera;
    public static bool miniGamePlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        miniGameCamera.GetComponent<Camera>().enabled = false;
        mainCamera.GetComponent<Camera>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.W))
        //{
            
        //}
    }

    void Switch()
    {

    }
}
