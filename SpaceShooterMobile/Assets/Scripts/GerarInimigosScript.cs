using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerarInimigosScript : MonoBehaviour {
	public GameObject inimigo;
	public float limiteEsquerdo, limiteDireito;


	IEnumerator Start () {
		// Aguarda a geração de inimigos
		yield return new WaitForSeconds(Random.Range(.5f, 2.0f));

		// Sorteia posição em X para instanciar o inimigo
		Vector2 posicao = new Vector2 (
			Random.Range(limiteEsquerdo, limiteDireito),
			transform.position.y);


		//Instancia o inimigo
		Instantiate(inimigo, posicao, transform.rotation);

		// Loop
		StartCoroutine (Start ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
