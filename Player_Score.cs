using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour {

	//GameObjects
	private GameStatus gs;
	private GameManager gm;

	//UI GameObjects
	public GameObject playerScoreUI;
	public GameObject keyGreenUI;
	public GameObject keyRedUI;

	//Variables
	//private float timeLeft = 120; //120 = 2 minutes
	public bool keyGreen = false;
	public bool keyRed = false;

	// Use this for initialization
	void Start () {
		keyGreenUI.gameObject.GetComponent<Image>().enabled = false;
		keyRedUI.gameObject.GetComponent<Image>().enabled = false;
		gs = FindObjectOfType<GameStatus> ();
		gm = FindObjectOfType<GameManager> ();
	}

	// Update is called once per frame
	void Update () {

		// Update Score UI
		playerScoreUI.gameObject.GetComponent<Text>().text = ("Score : " + gs.GetLevelScore(gm.GetCurrentLevel()));

		//Update Green Key
		if (keyGreen == true) {
			keyGreenUI.gameObject.GetComponent<Image>().enabled = true;
		} else {
			keyGreenUI.gameObject.GetComponent<Image>().enabled = false;
		}

		//Update Red Key
		if (keyRed == true) {
			print ("holding red key");
			keyRedUI.gameObject.GetComponent<Image>().enabled = true;
		} else {
			print ("NOT holding red key");
			keyRedUI.gameObject.GetComponent<Image>().enabled = false;
		}
			
	}

	//Handle Collisions
	void OnTriggerEnter2D (Collider2D trig){
		//Normal Gameplay
		if (trig.gameObject.tag == "collectable") {
			gs.AddLevelScore(gm.GetCurrentLevel(), 10);
		}

		//Green Key
		if (trig.gameObject.tag == "keyGreen") {
			keyGreen = true;
		}

		//For Red Key
		if (trig.gameObject.tag == "keyRed") {
			keyRed = true;
		}
	}
}
