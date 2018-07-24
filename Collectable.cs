using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

	//Handle Collision
	void OnTriggerEnter2D (Collider2D target){

		//For Coin Pick Up
		if (target.gameObject.tag == "Player" && gameObject.tag == "collectable") {
			Destroy (gameObject);
		}

		//For Green Key Pick Up
		if (target.gameObject.tag == "Player" && gameObject.tag == "keyGreen") {
			Destroy (gameObject);
		}

		//For Green Key Use
		if (target.gameObject.tag == "Player" && gameObject.tag == "lockGreen") {
			if (target.gameObject.GetComponent<Player_Score> ().keyGreen == true) {
				Destroy (gameObject);
				target.gameObject.GetComponent<Player_Score> ().keyGreen = false;
			}

		}

		//For Red Key Pick Up
		if (target.gameObject.tag == "Player" && gameObject.tag == "keyRed") {
			Destroy (gameObject);
		}

		//For Red Key Use
		if (target.gameObject.tag == "Player" && gameObject.tag == "lockRed") {
			if (target.gameObject.GetComponent<Player_Score> ().keyRed == true) {
				Destroy (gameObject);
				target.gameObject.GetComponent<Player_Score> ().keyRed = false;
			}
		}

	}

}
