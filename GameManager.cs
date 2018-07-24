using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	//Static instance of GameManager which allows it to be accessed by any other script.
	public static GameManager instance = null; 

	//Return the Current Level
	public int GetCurrentLevel() {
		return SceneManager.GetActiveScene ().buildIndex;
	}

	//Identify Next Level for Load
	public void LoadNextLevel(int x){
		SceneManager.LoadScene (x);
	}

	//For Final Screen
	public void RestartGame() {
		DestroyObject(FindObjectOfType<GameStatus>());
		SceneManager.LoadScene (0);
	}
}
