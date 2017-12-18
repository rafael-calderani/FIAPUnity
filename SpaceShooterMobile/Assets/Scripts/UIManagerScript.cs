using UnityEngine;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour {
    public Text txtScore;
    public Text txtLives;
	
	// Update is called once per frame
	void Update () {
        txtScore.text = "Score: " + SpaceShooterScript.score.ToString();
        txtLives.text = "Lives: " + SpaceShooterScript.vida.ToString();

    }
}
