using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    // Variáveis globais
    public float velocidade, impulso, life;
	public Transform sensorEsquerda;
	public Transform sensorDireita;
    public static bool playerFlippedOnX;

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
		estaNoChao = Physics2D.Linecast(transform.position, sensorEsquerda.position,
            1 << LayerMask.NameToLayer("Piso")) ||
			Physics2D.Linecast(transform.position, sensorDireita.position,
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
        playerFlippedOnX = spriteRenderer.flipX;

        // Seta os parametros de animação de movimento do personagem
        animator.SetFloat("pRun", Mathf.Abs(input));
        animator.SetBool("pJump", !estaNoChao);
        animator.SetBool("pFire", Input.GetButton("Fire1"));
	}

	void OnTriggerEnter2D(Collider2D c) {
		// Destroi o projetil por colisao
		if (c.gameObject.tag == "SubInimigo") {
			life--;
			Destroy(c.gameObject);
			if (life <= 0) {
				Destroy(gameObject);
				// TODO: GAME OVER
			}
		}
	}
}
