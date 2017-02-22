using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {


    Collider door; //Collider to assign to doors later
    public LayerMask keyMask; // Allows for the ray to only detect keys
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); // creates a ray

        RaycastHit rayHit = new RaycastHit(); //creates variable to store ray data

        Debug.DrawRay(ray.origin, ray.direction * 5f, Color.yellow); // draws raycast in the editor

        if (Physics.Raycast(ray, out rayHit, 5f, keyMask)) //stores data in rayHit if a door is within 5 units of it
        {
            door = rayHit.collider; //stores the key's collider in the collider variable
            if (Input.GetMouseButtonDown(0) && GameManager.hasKeyOne == true) //checks to see input from mouse button 1 and if has a key
            {
                Debug.Log("it works");
                door.gameObject.transform.Rotate(0f, -90f, 0f);
               
            }


        }
    }
}
