using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.back);
	}

	void OnCollisionEnter2D(Collision2D c) {
		print ("Eita mano o " + c.collider.tag + " bateu no " + c.otherCollider);

		if (c.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	}

	void OnCollisionStaty2D(Collision2D c) {
		print ("Ainda tá relando jão...");
	}

	void OnCollisionExit2D(Collision2D c) {
		print ("Parou.");
	}
}
