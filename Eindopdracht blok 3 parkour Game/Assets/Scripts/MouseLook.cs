using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//alle groene teksten classes
//functies zijn geel
//ingebouwde functies zijn blauw donker 
//f staat voor float casten van een double naar een float
//bij int geen f achter het cijfer


public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;  //1:60 timedeltatime
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f,90f);

        transform.localRotation = Quaternion.Euler(xRotation,0f,0f); //pos,loc,schaal // localRot alleen de camera 
        playerBody.Rotate(Vector3.up*mouseX); // playerBody.rotation = Quaternion.Euler(0, yRotation, 0f); //vector 3 drie floats. 

    }
}
