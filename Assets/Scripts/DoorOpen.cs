﻿using System.Collections;
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
            //If they click and they have the right key for the right door, it rotates 90 degrees and then the collider gets removed
            // so you can't keep rotating it. I either need to add another that won't trigger the rotation or find a better way. 
            if (Input.GetMouseButtonDown(0)) 
            {
                if (door.gameObject.tag == "Door1" && GameManager.hasKeyOne == true)
                {
                    door.gameObject.transform.Rotate(0f, -90f, 0f);
                    Destroy(door.gameObject.GetComponent<MeshCollider>());
                }
                if (door.gameObject.tag == "Door2" && GameManager.hasKeyTwo == true)
                {
                    door.gameObject.transform.Rotate(0f, -90f, 0f);
                    Destroy(door.gameObject.GetComponent<MeshCollider>());
                }
                if (door.gameObject.tag == "Door3" && GameManager.hasKeyThree == true)
                {
                    door.gameObject.transform.Rotate(0f, -90f, 0f);
                    Destroy(door.gameObject.GetComponent<MeshCollider>());
                    Debug.Log("Used Key3");
                }

            }


        }
    }
}