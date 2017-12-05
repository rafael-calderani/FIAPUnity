using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverFundo : MonoBehaviour {

	public float velocidade;
	public float posicaoInicial, posicaoFinal;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x <= posicaoFinal) {
			transform.position = new Vector2 (posicaoInicial, transform.position.y);
		}
		transform.Translate (Vector2.left * velocidade * Time.deltaTime);
	}
}
