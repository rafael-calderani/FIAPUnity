using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerarAboborasScript : MonoBehaviour {
	public float limiteEsquerdo, limiteDireito, limiteFrontal, limiteTraseiro;
	public float frequencia;
	public GameObject aboboraPrefab;

	// Use this for initialization
	IEnumerator Start () {		
		yield return new WaitForSeconds (Random.Range(0.5f, frequencia));
		Vector3 pos = new Vector3 ();
		pos.x = Random.Range (limiteEsquerdo, limiteDireito);
		pos.y = transform.position.y;
		pos.z = Random.Range (limiteFrontal, limiteTraseiro);
		Instantiate (aboboraPrefab, pos, transform.rotation);

		StartCoroutine (Start ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
