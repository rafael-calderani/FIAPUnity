using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {
    public GameObject projetil;

    SpriteRenderer spriteRenderer;
    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        // caso o player troque de lado a posição da arma deve acompanhar
        bool chargedShot = false;
        if (Input.GetButton("Fire1")) {
            //TODO: charge the shot if player holds for 3s
        }

        // Disparo do projetil
        if (Input.GetButtonUp("Fire1")) {
            Vector3 position = transform.position;
            position.x += (PlayerScript.playerFlippedOnX) ? -0.2f : 0.2f;
            Instantiate(projetil, position, transform.rotation);
        }
    }
}
