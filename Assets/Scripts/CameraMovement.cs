using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float verticalTurn; //vertical camera movement
    //float horizontalTurn; //horizontal camera movement
    public float cameraSpeed = 1; //how fast the camera turns
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //float mouseX = Input.GetAxis("Mouse X"); //grabs horizontal mouse inputs
        float mouseY = Input.GetAxis("Mouse Y");//grabs vertical mouseinputs
        verticalTurn = -mouseY * Time.deltaTime * cameraSpeed; //assigns value to verticalTurn
        //horizontalTurn = mouseX * Time.deltaTime * cameraSpeed; //assigns value to verticalTurn
        transform.Rotate(verticalTurn, 0f, 0f); //rotates camera
    }
}
