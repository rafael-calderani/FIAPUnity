using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blink : MonoBehaviour {
	public float intervalo;

	// Use this for initialization
	IEnumerator Start () {
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer> ();

		spriteRenderer.enabled = !spriteRenderer.enabled;
		yield return new WaitForSeconds(intervalo);

		StartCoroutine (Start ());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) { // Enter pressionado
			SceneManager.LoadScene("GameScene");
		}

	}
}
