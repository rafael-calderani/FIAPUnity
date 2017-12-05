using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBird : MonoBehaviour {
	public float forcaY;
	public Rigidbody2D flappyBody;
	// Use this for initialization
	void Start () {
		flappyBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Jump")) {
			flappyBody.velocity = new Vector2 (0.0f, forcaY);
		}
	}
}
