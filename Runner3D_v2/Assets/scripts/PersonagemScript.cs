using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemScript : MonoBehaviour {
	
	Vector3 novaPosicao;
	Animation animacao;

	public float velocidade;
	public GameObject personagem;

	// Use this for initialization
	void Start () {
		// captura a posição inicial do personagem
		novaPosicao = transform.position;

		// define a animacao inicial do personagem
		animacao = personagem.GetComponent<Animation>();
		animacao.CrossFade ("idle");
	}
	
	// Update is called once per frame
	void Update () {
		// Touch ou click do mouse
		if (Input.GetButton("Fire1")) {

			// Captura as coordenadas do clique ou touch
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit) && (hit.collider.gameObject.tag != "Player")) {
				
				novaPosicao = new Vector3(hit.point.x, novaPosicao.y, hit.point.z);

				// move o personagem
				transform.position = Vector3.MoveTowards (
					transform.position,
					novaPosicao, velocidade * Time.deltaTime);
				
				transform.LookAt (hit.point);

				animacao.CrossFade ("run");

			} else {

				animacao.CrossFade ("idle");
			}
		}
	}

	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "Item") {
			Destroy (c.gameObject);
		}
	}
}
