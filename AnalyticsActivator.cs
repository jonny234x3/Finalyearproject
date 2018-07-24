using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyticsActivator : MonoBehaviour {

	//GameObject
	[SerializeField]
	GameObject collisionObject;

	//Handle Collision of GameObject with this Object
	void OnTriggerEnter2D (Collider2D target) {

		//Check for collison with Circle Collider componenent or Box Collider component
		if ((target == collisionObject.GetComponent<CircleCollider2D>() ||
			target == collisionObject.GetComponent<BoxCollider2D>() ) && gameObject.tag == "analytic") {

			//Enable the analytic GameObject child of this object
			transform.GetChild(0).gameObject.SetActive(true);
			Debug.Log ("Send Analytic for " + gameObject.name); //For Editor Only
		}

	}

}
