using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IniciarScript : MonoBehaviour {
	void Start(){
		FlappyBirdScript.gameStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)
			|| Input.touchCount == 2) {
			PrincipalScript.pontos = 0;
			SceneManager.LoadScene ("game");
		}
	}
}
