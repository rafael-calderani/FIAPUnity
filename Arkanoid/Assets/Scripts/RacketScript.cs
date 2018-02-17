using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketScript : MonoBehaviour {
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Get Horizontal Input
        float h = Input.GetAxisRaw("Horizontal");

		// Get touch for mobile and set -1 or 1 according to position x
		if (Input.touchCount > 0) {
			h = (Input.touches [0].position.x < transform.position.x) ? -1 : 1;
		}

        // Set Velocity (movement direction * speed)
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
    }
}
