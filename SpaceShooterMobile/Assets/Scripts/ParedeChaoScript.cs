using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedeChaoScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D c) {
        if (c.gameObject.tag == "Inimigo") { // Inimigo passou pela parede
            SpaceShooterScript.score = SpaceShooterScript.score -5;
            if (SpaceShooterScript.score < 0) SpaceShooterScript.score = 0;
        }
    }
}
