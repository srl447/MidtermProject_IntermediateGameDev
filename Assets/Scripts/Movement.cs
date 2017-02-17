using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController characterControl; //makes character controller
    Vector3 movementDirection; //direction for where the character moves
    public float speed = 1; //how fast the character moves
    public float camSpeed = 1; //camera speed for horizontal
    public float relativeHorizontal;
    public float relativeVertical;
    public float angle;
	void Start ()
    {
        characterControl = GetComponent<CharacterController>(); //assigns the character controller
	}
	
	void Update ()
    {
        angle = transform.eulerAngles.y * Mathf.PI / 180; //assigns the rotation to angle
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //Gets horizontal inputs from a/d and left/right arrows keys
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime; //Gets vertical inputs from w/s and up/down arrow keys
        float mouseX = Input.GetAxis("Mouse X"); //Gets horizontal mouse movements

        if (angle > 0)
        {
            relativeHorizontal =  horizontal * Mathf.Sin(angle) - vertical * Mathf.Cos(angle);
            relativeVertical  =  horizontal * Mathf.Cos(angle) + vertical * Mathf.Sin(angle);
        }
        //this translates the horizontal and vertical movement to the characters current rotation
        /*if (angle > 0)
        {
            relativeHorizontal = horizontal * Mathf.Cos(angle) - vertical * Mathf.Sin(angle);
            relativeVertical = horizontal * Mathf.Sin(angle) + vertical * Mathf.Cos(angle);
        }
        // accounts for a weird case where a negative angle would occur
        else
        {
            relativeHorizontal = horizontal * Mathf.Cos(angle) + vertical * Mathf.Sin(angle);
            relativeVertical = - horizontal * Mathf.Sin(angle) + vertical * Mathf.Cos(angle);
        }*/
        movementDirection = new Vector3(relativeHorizontal, 0f, relativeVertical); //assigns inputs in a vector

        characterControl.Move(movementDirection);//uses the character controller to move
        //characterControl.Move(horizontal * Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(0f, mouseX * Time.deltaTime * camSpeed, 0f);
        
    }
}
