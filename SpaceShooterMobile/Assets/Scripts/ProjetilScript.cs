using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilScript : MonoBehaviour {
	public float velocidade;
	public float tempoDeVida;
	public GameObject fxExplosao;

	// Use this for initialization
	void Start () {
		// Configura tempo de vida do projetil
		Destroy(gameObject, tempoDeVida);
	}
	
	// Update is called once per frame
	void Update () {
		// Move o projetil
		transform.Translate(Vector2.up * velocidade * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D c) {
		// Destroi o projetil por colisao
		if (c.gameObject.tag == "Inimigo") {
			GameObject ex = Instantiate (fxExplosao, transform.position, transform.rotation);

			Destroy (c.gameObject);
			Destroy (gameObject);
			Destroy (ex, 0.5f);
		}
	}
}
