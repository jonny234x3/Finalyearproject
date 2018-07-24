using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	//GameObjects
	[SerializeField]
	GameObject PauseMenu;
	[SerializeField]
	GameObject HelpMenu;
	[SerializeField]
	GameObject levelUI;

	//Menu States
	enum MenuStates { Playing, Pause, Help}
	MenuStates currentState;

	// Used for pre-initialization on Splash Screen
	void Awake(){
		if (SceneManager.GetActiveScene ().buildIndex == 0) {
		} else {
			currentState = MenuStates.Playing;
		}
	}

	// Use this for initialization
	void Start () {
		//Default Set UI to false, if they aren't already
		PauseMenu.SetActive(false);
		HelpMenu.SetActive(false);
	}

	// Update is called once per frame
	void Update () {

		//Update Level UI
		levelUI.gameObject.GetComponent<Text>().text = ("Level : " + SceneManager.GetActiveScene ().buildIndex);

		//Toggle the Pause Menu with ESC or P
		if (Input.GetKeyDown("escape") && currentState == MenuStates.Pause){
			currentState = MenuStates.Playing;
		}else if (Input.GetKeyDown("escape") && currentState == MenuStates.Playing){
			currentState = MenuStates.Pause;
		}

		//Control the States

		switch (currentState){
		case MenuStates.Playing:
			PauseMenu.SetActive (false);
			HelpMenu.SetActive (false);
			//DeadMenu.SetActive (false);
			Time.timeScale = 1;
			break;

		case MenuStates.Pause:
			PauseMenu.SetActive (true);
			HelpMenu.SetActive (false);
			//DeadMenu.SetActive (false);
			Time.timeScale = 0;
			break;

		case MenuStates.Help:
			PauseMenu.SetActive (false);
			HelpMenu.SetActive (true);
			//DeadMenu.SetActive (false);
			Time.timeScale = 0;
			break;

		}

	}

	//Button Options

	public void Restart () {
		//Loads Current Scene
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void Resume () {
		currentState = MenuStates.Playing;
	}

	public void Help () {
		currentState = MenuStates.Help;
	}

	public void Back () {
		currentState = MenuStates.Pause;
	}

	public void Quit () {
		// Load Main Menu, A.K.A Scene 0
		SceneManager.LoadScene (0); 
	}

}
