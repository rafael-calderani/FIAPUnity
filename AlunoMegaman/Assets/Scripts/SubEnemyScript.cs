using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubEnemyScript : MonoBehaviour {
	public GameObject target;
	public float velocidade;


	// Use this for initialization
	void Start () {
		// Define alvo
		target = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) return;

		// fazer o flip X de acordo com o player
		float flipCheck = transform.position.x - target.transform.position.x;
		GetComponent<SpriteRenderer> ().flipX = flipCheck < 0;

		// Persegue o alvo
		transform.position = Vector2.Lerp(
			transform.position, target.transform.position,
			velocidade * Time.deltaTime);
	}
}
