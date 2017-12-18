using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JogadorScript : MonoBehaviour {
	public float velocidade;
	public float limiteEsquerdo, limiteDireito;
    public GameObject fxExplosao;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		Mover ();
	}

	void Mover() {
		// Mover
		float move_x = Input.GetAxisRaw ("Horizontal") * velocidade * Time.deltaTime;
		float move_y = Input.GetAxisRaw ("Vertical") * velocidade * Time.deltaTime;

		transform.Translate (move_x, move_y, 0.0f);

		// Wrap
		if (transform.position.x < limiteEsquerdo || transform.position.x > limiteDireito) {
			transform.position = new Vector2 (transform.position.x * -1, transform.position.y);
		}
	}

	void OnCollisionEnter2D(Collision2D c) {
		if (c.gameObject.tag == "Inimigo") {
			GameObject ex = Instantiate (fxExplosao, c.transform.position, c.transform.rotation);
			Destroy (ex, 0.5f);
            SpaceShooterScript.vida--;
            SpaceShooterScript.score++;

			Destroy(c.gameObject);
			if (SpaceShooterScript.vida <= 0) {
				GameObject ex2 = Instantiate (fxExplosao, transform.position, transform.rotation);
				Destroy (ex2, 0.5f);
				Destroy (gameObject);

                StartCoroutine("GameRestart", 1.0f);
            }	
		}
	}

    private bool isRestarting = false;

    IEnumerator GameRestart(float waitTime) {
        if (isRestarting) yield break;

        isRestarting = true;
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("Start");
        isRestarting = false;
    }
}
