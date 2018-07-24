using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

	private GameObject player;
	//Variables
	//Used to Define Camera Bounding Area
	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Better version of Update for Camera
	void LateUpdate () {
		//Clamp Camera to Player
		float x = Mathf.Clamp (player.transform.position.x, xMin, xMax);
		float y = Mathf.Clamp (player.transform.position.y, yMin, yMax);
		//Move Camera
		gameObject.transform.position = new Vector3 (x, y, gameObject.transform.position.z);

	}
}
