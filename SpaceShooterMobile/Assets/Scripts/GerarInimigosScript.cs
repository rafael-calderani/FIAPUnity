using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerarInimigosScript : MonoBehaviour {
	public GameObject inimigo;
	public float limiteEsquerdo, limiteDireito;
    public float geracaoDeInimigoMin, geracaoDeInimigoMax;



    IEnumerator Start () {
        geracaoDeInimigoMin = .5f - (SpaceShooterScript.score/200);
        if (geracaoDeInimigoMin < .1f) geracaoDeInimigoMin = .1f;
        geracaoDeInimigoMax = 3.0f - (SpaceShooterScript.score / 200);
        if (geracaoDeInimigoMax < .3f) geracaoDeInimigoMax = .3f;

        // Aguarda a geração de inimigos
        yield return new WaitForSeconds(Random.Range(geracaoDeInimigoMin, geracaoDeInimigoMax));

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
