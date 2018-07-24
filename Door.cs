using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	//GameObjects
	GameManager gm;

	//Varaible
	public int nextLevel;

	// Use this for initialization
	void Start () {
		gm = FindObjectOfType<GameManager> ();
	}

	// Load Next Level
	void OnTriggerEnter2D (Collider2D trig){
		gm.LoadNextLevel (nextLevel);
	}

}

