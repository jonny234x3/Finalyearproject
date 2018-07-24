using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToContinue : MonoBehaviour {

	//For Use on Splash Screen

	//Variables
	//public string scene;
	private bool loadLock;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && !loadLock){
			LoadScene ();
		}
	}

	void LoadScene(){
		loadLock = true;
		SceneManager.LoadScene (1);
	}
}
