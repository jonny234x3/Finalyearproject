using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalCount : MonoBehaviour {

	//GameObject
	GameStatus gs;

	//UI GameObjects
	public GameObject level2ScoreUI;
	public GameObject level3ScoreUI;
	public GameObject level4ScoreUI;
	public GameObject level5ScoreUI;
	public GameObject totalScoreUI;
	public GameObject totalDeathsUI;

	// Use this for initialization
	void Start () {
		gs = FindObjectOfType<GameStatus> ();
	}
	
	// Update is called once per frame
	void Update () {

		level2ScoreUI.gameObject.GetComponent<Text>().text = (
			"Level : 2   " + 
			"  Score :   " + gs.GetLevelScore (2) + 
			"  Deaths :   " + gs.GetLevelDeathCount (2) );
		
		level3ScoreUI.gameObject.GetComponent<Text>().text = (
			"Level : 3   " + 
			"  Score :   " + gs.GetLevelScore (3) + 
			"  Deaths :   " + gs.GetLevelDeathCount (3) );
		
		level4ScoreUI.gameObject.GetComponent<Text>().text = (
			"Level : 4   " + 
			"  Score :   " + gs.GetLevelScore (4) + 
			"  Deaths :   " + gs.GetLevelDeathCount (4) );
		
		level5ScoreUI.gameObject.GetComponent<Text>().text = (
			"Level : 5   " + 
			"  Score :   " + gs.GetLevelScore (5) + 
			"  Deaths :   " + gs.GetLevelDeathCount (5) );
		
		totalScoreUI.gameObject.GetComponent<Text>().text = (
			"  Score : " + gs.GetTotalScore() );

		totalDeathsUI.gameObject.GetComponent<Text>().text = (
			"  Deaths : " + gs.GetTotalDeathCount() );
	}
}
