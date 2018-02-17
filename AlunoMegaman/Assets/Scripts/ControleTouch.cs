using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.CrossPlatformInput;

public class ControleTouch : MonoBehaviour {
	public float velocidade;
	public Animator anima;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float mover_x = CrossPlatformInputManager.GetAxis ("Horizontal") * velocidade * Time.deltaTime;
		float mover_y = CrossPlatformInputManager.GetAxis ("Vertical") * velocidade * Time.deltaTime;

		print (mover_x);

		transform.Translate (new Vector3 (mover_x, mover_y));
	}
}
