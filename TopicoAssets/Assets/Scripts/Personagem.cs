using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour {
	public float velocidade;

	// Use this for initialization
	void Start () {
		// executa uma única vez
		//print("começou out baguio mano");
		//transform.position = new Vector2 (-10.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		// fica em loop
		//transform.Translate (3.0f * Time.deltaTime, 0.0f, 0.0f);
		//transform.Rotate (Vector3.forward*velocidade*Time.deltaTime);
		//print (Input.GetAxis("Horizontal"));
		float moveX = Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;
		float moveY = Input.GetAxis("Vertical") * velocidade * Time.deltaTime;
		transform.Translate (moveX, moveY, 0.0f);

		// Input com retorno booleano
		if (Input.GetButtonDown("Jump")) {
			transform.position = Vector2.zero;

			SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
			spriteRenderer.flipX = !spriteRenderer.flipX;
		}
	}
}
