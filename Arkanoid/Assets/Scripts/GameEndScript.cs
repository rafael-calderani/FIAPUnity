using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEndScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text txtLastScore = GameObject.Find("txtLastScore").GetComponent<Text>();
		txtLastScore.text = string.Format("You Scored: {0}", GameStartScript.score);

		Text txtBestScore = GameObject.Find("txtBestScore").GetComponent<Text>();
		txtBestScore.text = string.Format("Best Score: {0}", GameStartScript.bestScore);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)
			|| Input.touchCount > 0) {
			BallScript.ballSpeed = 0.0f;
			GameStartScript.alpha = 0.0f;
			SceneManager.LoadScene("Main");
		}
	}
}
