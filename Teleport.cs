using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
	
	//This Class Isn't Used In The Final Project

	public GameObject sp2;
	public static bool canTransport; // apparently this implementation is bad
	//private SpriteRenderer sp;

	void Start () {
		//sp = GetComponent<SpriteRenderer> ();
		canTransport = true;
	}

	void OnTriggerEnter2D (Collider2D trig){
		if(canTransport == true) {
			trig.gameObject.transform.position = sp2.gameObject.transform.position;
			canTransport = false;
		}
	}

	void OnTriggerExit2D (Collider2D trig){
		//coroutine for time sensitive result
		StartCoroutine ("TeleportDisable");
	}
		
	//if using this think about implementing a cool down animation.
	IEnumerator TeleportDisable (){
		var timer = 0.0f;
		while (!canTransport) {
			timer += Time.deltaTime;
			//sp.color = Color.Lerp(/*original colour*/, Color.red, timer);

			if (timer >= 5.0f) {
				canTransport = true;
			}
			yield return null;
		}
	}

}

