using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelScript : MonoBehaviour {

	public float speed = 3f;
	
	// Update is called once per frame
	void Update () {

		//get the position
		Vector2 position = transform.position;

		//set new position to move left in x direction
		position = new Vector2 (position.x - speed * Time.deltaTime, position.y);

		//set the position
		transform.position = position;

		//destroy if off screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0));
		if (transform.position.x < min.x) {
			Destroy (gameObject);
		}
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "monkeyTag") {
			Destroy (gameObject);
		}
	}
}
