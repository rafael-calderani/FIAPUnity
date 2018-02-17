using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGeneratorScript : MonoBehaviour {
    public GameObject blockDefault;
    public float posicaoY = 4.0f;
    public float posicaoX = -3.0f;

    // Use this for initialization
    IEnumerator Start() {

        SpriteRenderer sr = blockDefault.GetComponent<SpriteRenderer>();
        if (posicaoY == 4.0f) { sr.color = Color.blue; }

        if (posicaoX >= 3.0f) { // Trocar o bloco, reseta posição X e redefine posição Y
            posicaoX = -3.0f;
            posicaoY = posicaoY - 0.3f;

            // Trocar bloco de acordo com a posição Y
            if (posicaoY == 3.7f) { sr.color = Color.red; }
            else if (posicaoY == 3.4f) { sr.color = Color.green; }
            else { sr.color = Color.magenta; }
        }

        // Define vetor e posição X para instanciar os blocos
        Vector2 posicao = new Vector2(posicaoX, posicaoY);

        

        // Aguarda a geração de inimigos
        yield return new WaitForSeconds(.03f);

        // Loop
        if (posicaoY > 3.0f) {
            //Instancia o inimigo
            Instantiate(blockDefault, posicao, transform.rotation);
            posicaoX = posicaoX + 0.3f;

            StartCoroutine(Start());
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
