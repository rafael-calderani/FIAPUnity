using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartScript : MonoBehaviour {
    public static int life;
	public static int score;
	public static int bestScore;
    public static float alpha = 0.0f;

    // Use this for initialization
    IEnumerator Start () {
        alpha = alpha + .025f;
        score = 0;
        life = 3;

        // set color of the UI Text
        Color textColor = GameObject.Find("StartMessage").GetComponent<Text>().color;

        textColor = new Color(textColor.r, textColor.g, textColor.b, alpha);
        GameObject.Find("StartMessage").GetComponent<Text>().color = textColor;

        Text touchMessage = GameObject.Find("TouchMessage").GetComponent<Text>();
        touchMessage.color = textColor;
        touchMessage.text = "Touch anywehere to start";
        yield return new WaitForSeconds(.1f);

        // Loop
        if (alpha < 1.0f) StartCoroutine(Start());
    }
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)
			|| Input.touchCount > 0) && (alpha >= 1.0f)) {
            Color textColor = GameObject.Find("TouchMessage").GetComponent<Text>().color;
            if (textColor.a > 0.9f) {
                BallScript.ballSpeed = 6.4f;
                Color hiddenTextColor = new Color(textColor.r, textColor.g, textColor.b, 0);
                Color visibleTextColor = new Color(textColor.r, textColor.g, textColor.b, 255);

                GameObject.Find("StartMessage").GetComponent<Text>().color = hiddenTextColor;
                GameObject.Find("Lives").GetComponent<Text>().color = visibleTextColor;
                GameObject.Find("Score").GetComponent<Text>().color = visibleTextColor;

                Text touchMessage = GameObject.Find("TouchMessage").GetComponent<Text>();
                touchMessage.color = hiddenTextColor;
                touchMessage.text = "Touch anywehere to continue";
            }
        }
    }

    public static void UpdateCanvas() {
        GameObject.Find("Lives").GetComponent<Text>().text = string.Format("Lives: {0}", life);
        GameObject.Find("Score").GetComponent<Text>().text = string.Format("Score: {0}", score);

		if (score > bestScore) bestScore = score;
    }
}
