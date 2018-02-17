using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
	public float life;
	public float interval;
	public GameObject inimigosPrefab;
	public Transform geradorPeixes;

	// Use this for initialization
	IEnumerator Start () {
		Instantiate (inimigosPrefab, 
			geradorPeixes.transform.position,
			geradorPeixes.transform.rotation);

		yield return new WaitForSeconds (interval);
		StartCoroutine (Start ());
	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag == "Fire") {
			life--;
			if (life <= 0) {
				Destroy (gameObject);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
