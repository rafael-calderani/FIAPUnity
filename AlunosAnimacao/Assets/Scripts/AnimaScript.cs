using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaScript : MonoBehaviour {

	public float velocidade;
	Animator animator;
	SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		// pega o input de movimento horizontal do jogador
		float input = Input.GetAxisRaw ("Horizontal");
		float mover_x = input * velocidade * Time.deltaTime;
		transform.Translate (mover_x, 0.0f, 0.0f); // move o personagem

		// Orientação do personagem
		if (mover_x != 0) {
			spriteRenderer.flipX = (mover_x < 0.0f);
		}

		// Reproduz animação de movimento do personagem
		animator.SetFloat("pMover", Mathf.Abs(input));
	}
}
