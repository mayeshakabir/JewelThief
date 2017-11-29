using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour {

	public float speed;
	public Vector2 directionToGo;
	public bool isDirectionSet;

	void Awake() {
		speed = 17f;
		isDirectionSet = false;
	}

	// Use this for initialization
	void Start () {
		
	}

	public void setDirection(Vector2 direction) {

		directionToGo = direction.normalized;
		isDirectionSet = true;
		
	}
	
	// Update is called once per frame
	void Update () {

		if (isDirectionSet) {

			//get bombs position
			Vector2 position = transform.position;

			//set which position to go
			position += directionToGo * speed * Time.deltaTime;

			//update position
			transform.position = position;

			//destroy if off screen
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0));
			if (transform.position.x < min.x) {
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col) {

		if (col.tag == "monkeyTag") {
			Destroy (gameObject);
		}
	}
}
