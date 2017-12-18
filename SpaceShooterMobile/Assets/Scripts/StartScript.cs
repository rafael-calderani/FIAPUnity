using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SpaceShooterScript.gameStarted = false;
        SpaceShooterScript.scoreLife = 100;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)
            || Input.touchCount > 0) {
            SpaceShooterScript.score = 0;
            SpaceShooterScript.vida = 3;
            SceneManager.LoadScene("Game");
        }
    }
}
