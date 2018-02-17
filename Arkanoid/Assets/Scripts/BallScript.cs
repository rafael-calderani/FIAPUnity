using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour {
    // Movement Speed
    public static float ballSpeed;

    // Use this for initialization
    void Start () {}
    private void Update() {
        if (GetComponent<Rigidbody2D>().velocity == Vector2.zero) {
            GetComponent<Rigidbody2D>().velocity = Vector2.down * ballSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D c) {
        // Hit the Racket?
        if (c.gameObject.tag == "Player") {
            // Calculate hit Factor
            float x = hitFactor(transform.position,
                              c.transform.position,
                              c.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * ballSpeed;
        }
        else if (c.gameObject.tag == "block") {
            GameStartScript.score++;
            //TODO: update canvas
        }
        else if (c.gameObject.tag == "floor") {
            GameStartScript.life--;
            if (GameStartScript.life > 0) {
                c.gameObject.GetComponent<AudioSource>().Play();
                Transform ballTransform = GetComponent<Transform>();
                ballSpeed = 0.0f;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                Text touchMessage = GameObject.Find("TouchMessage").GetComponent<Text>();
                touchMessage.color = new Color(touchMessage.color.r, touchMessage.color.g, touchMessage.color.b, 255);
                ballTransform.position = new Vector3(0.0f, -4.0f);
            }
            else {
                // todo: fade effect
                SceneManager.LoadScene("EndGame");
            }
        }
        GameStartScript.UpdateCanvas();
        GetComponent<AudioSource>().Play();
    }
    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth) {
        // ascii art:
        //
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket
        //
        return (ballPos.x - racketPos.x) / racketWidth;
    }
}
