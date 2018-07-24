using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData {

	//Variables
	public int LevelID;
	public int LevelScore;
	public int DeathCount;

	//Level Data
	public LevelData(int LevelID, int LevelScore, int DeathCount) {
		this.LevelID = LevelID;
		this.LevelScore = LevelScore;
		this.DeathCount = DeathCount;
	}
}