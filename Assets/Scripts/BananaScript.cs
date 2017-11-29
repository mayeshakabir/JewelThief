using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BananaScript : MonoBehaviour {

	public float speed = 15f;

	int score = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		//get the position
		Vector2 position = transform.position;

		//set new position to move right in x direction
		position = new Vector2 (position.x + speed * Time.deltaTime, position.y);

		//set new position
		transform.position = position;

		//destroy if off screen
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1,1));
		if (transform.position.x > max.x) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {

		if (col.tag == "enemyTag") {

			score++;

			Destroy (gameObject);
		}
	}
		
}