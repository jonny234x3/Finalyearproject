using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookForward : MonoBehaviour {

	//Variables
	public Transform sightStart, sightEnd;
	private bool collision;
	public string layer = "Solid"; // Used to check if the collision object is solid
	public bool needsCollision = true;

	// Update is called once per frame
	void Update () {

		//LookForward
		collision = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer ("Solid"));

		//For Editor Only
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);

		if (collision == needsCollision) {
			//Flip
			//Note: This is using 2 as the scale of the objects animation is 1/2 the scale
			transform.localScale = new Vector3 (transform.localScale.x == 2 ? -2 : 2, 2, 2);
		}
	}
}
