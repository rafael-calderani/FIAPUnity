using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text txtLastScore = GameObject.Find("txtLastScore").GetComponent<Text>();
		txtLastScore.text = "You Scored: " + GameStartScript.score;

		// TODO: Best score
		Text txtBestScore = GameObject.Find("txtBestScore").GetComponent<Text>();
		txtBestScore.text = "Best Score: " + GameStartScript.score;		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
