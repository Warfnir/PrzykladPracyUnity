using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Camera characterCamera;
    public float rotationSpeed = 1f;    //Camera rotation speed
    public float minRotation = -90f;    //minimal camera rotation in X
    public float maxRotation = 90f;     //maximal camera rotation in X

    //Actual local camera rotation in X axis
    private float actRotation;

    // Start is called before the first frame update
    void Start()
    {
        actRotation = characterCamera.transform.localEulerAngles.x;   
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate rotation based on input
        //Rotate player in Y axis and camera in X
        Vector3 rotation = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation.y, 0);
        actRotation += rotation.x;
        actRotation = Mathf.Clamp(actRotation, -90, 90); 
        characterCamera.transform.localEulerAngles = new Vector3(actRotation, 0, 0);
    }
}
