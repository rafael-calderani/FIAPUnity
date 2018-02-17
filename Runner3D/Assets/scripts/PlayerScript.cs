using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public Transform[] posicoes;
	public float velocidade;

	float direcao_x, posicaoInicial_x, posicaoFinal_x;
	float direcao_y, posicaoInicial_y, posicaoFinal_y;
	int posicaoAtual = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) { // Fire1 = mouse click, touch or Left Ctrl

			// posição do toque da tela (mouse)
			posicaoInicial_x = Input.mousePosition.x;
			posicaoInicial_y = Input.mousePosition.y;
		}
		else if (Input.GetButtonUp ("Fire1")) {
			// posição do toque da tela (mouse)
			posicaoFinal_x = Input.mousePosition.x;
			posicaoFinal_y = Input.mousePosition.y;

			//define a direção
			direcao_x = posicaoFinal_x - posicaoInicial_x;

			if (direcao_x > 0 && posicaoAtual < 2) {
				posicaoAtual++;
			}
			else if (direcao_x < 0 && posicaoAtual > 0) {
				posicaoAtual--;
			}
		}

		//Desloca o cupo para a posição atual
		transform.position = Vector3.Lerp(transform.position,
			posicoes[posicaoAtual].position,
			velocidade * Time.deltaTime);

		if (posicaoAtual == 0) {
		} else if (posicaoAtual == 1) {
		} else {
		}
	}
}
