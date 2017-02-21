using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour
{

    Collider key;
    public LayerMask keyMask;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); // creates a ray

        RaycastHit rayHit = new RaycastHit(); //creates variable to store ray data

        Debug.DrawRay(ray.origin, ray.direction * 5f, Color.yellow); // draws raycast in the editor

        if (Physics.Raycast(ray, out rayHit, 5f, keyMask))
        {
            key = rayHit.collider;
            if (Input.GetMouseButtonDown (0))
            {
                Debug.Log("it works");
                Destroy(key.gameObject);
                GameManager.hasKeyOne = true;
            }
            
               
        }
    }
}
