using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyBirdScript : MonoBehaviour {
	// Variáveis
	public static bool gameStarted;
	public float impulso;

	// Componentes
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		// Instancias
		rb = GetComponent<Rigidbody2D> ();

		// Configurações iniciais
		gameStarted = false;
		rb.gravityScale = 0.0f; // desabilita gravidade
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameStarted && Input.GetButtonDown ("Fire1")) {
			gameStarted = true;
			rb.gravityScale = 1.0f;
		}
		else if (gameStarted && Input.GetButtonDown ("Fire1")) {
			rb.velocity = new Vector2 (0.0f, impulso);
		}
	}

	// Detecta colisão com trigger
	void OnTriggerEnter2D(Collider2D c) {
		PrincipalScript.pontos++;
	}

	//Detecta colisão normal
	void OnCollisionEnter2D(Collision2D c) {
		SceneManager.LoadScene ("start");
	}
}
