using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
	//GameObjects
	GameStatus gs;
	GameManager gm;

	//UI GameObjects
	[SerializeField]
	GameObject DeathUI;

	//Variables

	//Player Movement
	public int playerspeed = 5;
	private float moveX; 

	//Reference to animator
	Animator anim;

	//Player Jump
	public int playerJumpPower = 1;
	public bool canJump = true; //For Wait Function to make player only jump once
	private bool waitActive = false; //so wait function wouldn't be called many times per frame

	//Player Death
	public bool isDead = false; //Player Death


	//Start is called at the beginning
	void Start(){
		anim = GetComponent<Animator> ();
		//Ensure player is not dead
		anim.SetBool ("IsDead", false);
		DeathUI.SetActive(false);
		gs = FindObjectOfType<GameStatus> ();
		gm = FindObjectOfType<GameManager> ();
	}

	// Update is called once per frame
	void Update(){
		//Kill Player if they fall below map
		if (gameObject.transform.position.y < -7) {
			if (!isDead) {
				Die ();
			}
		}

		//Runs Player Movement if player is not dead
		if (!isDead) {
			PlayerMove ();
			PlayerRaycast ();
		}

	}

	//Handle Player Movement 

	void PlayerMove(){
		//Player Jump
		if (Input.GetButtonDown("Jump")){ //Default is space key
			//See if Player is allowed to jump
			if (!waitActive){
				StartCoroutine(Wait());
			}
			if(canJump){
				Jump ();
				canJump = false;
			}
		}

		//Player Walk
		moveX = Input.GetAxis("Horizontal");

		//Animate Player
		//Walking Animation for A Binary Animation Loop
		if (moveX != 0.0f) {
			GetComponent<Animator> ().SetBool ("IsRunning", true);
		} else {
			GetComponent<Animator> ().SetBool ("IsRunning", false);
		}

		//Player Direction
		if (moveX < 0.0f){
			GetComponent<SpriteRenderer> ().flipX = true;
		} else if (moveX > 0.0f){
			GetComponent<SpriteRenderer> ().flipX = false;
		}

		//Move Player
		//Default "move" buttons are arrow keys
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerspeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

	//Handle Player Jump

	void Jump(){
		//Player Jump
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower);
	}

	IEnumerator Wait(){
		waitActive = true;
		yield return new WaitForSeconds (0.5f);
		canJump = true;
		waitActive = false;
	}

	//Handle Player Death

	void Die () {
		//Changes dead variable
		isDead = true;
		//Death animation
		anim.SetBool ("IsDead", true);
		//increase death counter
		gs.AddLevelDeathCount (gm.GetCurrentLevel ());
		//enables death UI
		DeathUI.gameObject.SetActive(true);

	}

	//Handle Player Collisions

	void OnCollisionEnter2D (Collision2D target){
		//Kill Player if they collide with deadly tag
		if (target.gameObject.tag == "deadly") {
			if (!isDead) {
				Die ();
			}
		}
	}

	void PlayerRaycast () {

		//Position of Rays
		RaycastHit2D raydown = Physics2D.Raycast (transform.position, Vector2.down);
		Debug.DrawRay (transform.position, Vector2.down, Color.red);
		RaycastHit2D rayup = Physics2D.Raycast (transform.position, Vector2.up);
		// rayup != null && rayup.collider != null
		// Prevent Error when ray does not hit an object. - NOT GOOD IMPLEMENTATION

		//Collision Player with Weak Box
		if (raydown != null && raydown.collider != null && raydown.distance < 0.7f && raydown.collider.tag == "weakbox") {
			//Player Bounce
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 1000);
			//Destroy Box
			Destroy (raydown.collider.gameObject);
		}
		if (rayup != null && rayup.collider != null && rayup.distance < 0.5f && rayup.collider.tag == "weakbox") {
			//Destroy Box
			Destroy (rayup.collider.gameObject);
		}

		//Collision Player with Falling Box
		if (rayup != null && rayup.collider != null && rayup.distance < 0.5f && rayup.collider.tag == "box") {
			//Player Death
			Die();
		}

	}
}﻿