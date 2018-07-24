using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour {

	//GameObjects
	private Player_Score playerScore;
	private Player_Movement playerMove;
	private GameObject player; 

	//List to Hold Levels in List of "LevelData"
	private List<LevelData> levelData = new List<LevelData> ();

	// Use this for initialization
	void Start () {
		//Prevent this object from being destoryed
		DontDestroyOnLoad(this.gameObject);
	}

	//Getters
	public int GetLevelScore(int levelID){
		EnsureLevel (levelID);
		return levelData [levelID - 1].LevelScore;
	}

	public int GetLevelDeathCount(int levelID){
		EnsureLevel (levelID);
		return levelData [levelID - 1].DeathCount;
	}
		
	//Adders
	public void AddLevelScore(int levelID, int score) {
		EnsureLevel (levelID);
		levelData [levelID - 1].LevelScore += score;
		print ("Level Score Now: " + levelData [levelID - 1].LevelScore);
	}

	public void AddLevelDeathCount(int levelID) {
		EnsureLevel (levelID);
		levelData [levelID - 1].DeathCount ++;
		levelData [levelID - 1].LevelScore = 0;
		print ("Level Score Death: " + levelData [levelID - 1].LevelScore);
		print ("Death Count Now: " + levelData [levelID - 1].DeathCount);
	}
		
	//Get Level Data
	public List<LevelData> GetLevelData(){
		return levelData;
	}

	//Level Score Total
	public int GetTotalScore(){
		int score = 0;
		foreach (LevelData level in levelData) {
			score += level.LevelScore;
		}
		return score;
	}

	//Death Count Total
	public int GetTotalDeathCount(){
		int deathCount = 0;
		foreach (LevelData level in levelData) {
			deathCount += level.DeathCount;
		}
		return deathCount;
	}

	//Prevents Duplicates of Levels from being Added.
	public void EnsureLevel(int levelID){
		// Check doesn't already exist
		if (levelData.Count <= levelID - 1) {
			levelData.Add(new LevelData(levelID, 0, 0));
		}
	}
}
