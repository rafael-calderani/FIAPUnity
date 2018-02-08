﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    // Variáveis globais
    public float velocidade, impulso;
    public Transform chaoVerificador;

    // variáveis internas
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody2D;
    Animator animator;

    bool estaNoChao;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        // Verificar colisão com o piso
        estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.position,
            1 << LayerMask.NameToLayer("Piso"));

        // Mover
        float input = Input.GetAxisRaw("Horizontal");
        float mover_x = input * velocidade * Time.deltaTime;
        transform.Translate(mover_x, 0.0f, 0.0f); // horizontal

        if (Input.GetButtonDown("Jump") && estaNoChao) { // jump
            rigidbody2D.velocity = new Vector2(0.0f, impulso);
        }

        

        //Orientação
        if (mover_x != 0) {
            spriteRenderer.flipX = mover_x < 0;
        }

        // Reproduz animação de movimento do personagem
        animator.SetFloat("pRun", Mathf.Abs(input));
        animator.SetBool("pJump", !estaNoChao);
        animator.SetBool("pFire", Input.GetButton("Fire1"));

    }
}