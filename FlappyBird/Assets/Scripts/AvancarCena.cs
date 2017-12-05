using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// *** Faz toda a gestão de transição de cenas!! ***
using UnityEngine.SceneManagement;

public class AvancarCena : MonoBehaviour {

	public string cena;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		// Fire1 -> Touch, CTRL + Left, Click + Left
		if (Input.GetButtonDown ("Fire1")) {
			SceneManager.LoadScene (cena);
		}
	}
}
