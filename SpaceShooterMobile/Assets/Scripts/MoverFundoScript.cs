using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverFundoScript : MonoBehaviour {
	public float limiteY;
	public float velocidade;

	// Use this for initialization
	void Start () {	}
	
	// Update is called once per frame
	void Update () {
		// Desloca o fundo
		transform.Translate (Vector2.down * velocidade * Time.deltaTime);

		// Reposiciona o fundo para um novo ciclo
		if (transform.position.y <= limiteY) {
			transform.position = new Vector2 (0.0f, 0.0f);
		}
	}
}
