using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Move : MonoBehaviour {

	//Variables
	public int enemySpeed = 1;
	private Rigidbody2D body2D;

	void Start(){
		body2D = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		//Move Enemy using the Rigidbody2D
		body2D.velocity = new Vector2 (transform.localScale.x, 0) * enemySpeed;

		//if out of bounds then destroy
		if (gameObject.transform.position.y < -7) {
			Die();
		}

	}

	//Kill Enemy
	void Die () {
		Destroy (gameObject);
	}

}




