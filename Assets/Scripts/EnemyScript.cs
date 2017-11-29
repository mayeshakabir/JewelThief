using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {

	public GameObject bomb; //give it the gameObject varible
	public ParticleSystem bananaBomb;
	public ParticleSystem fireBomb;

	public float speed = 12f;

	// Use this for initialization
	void Start () {
		Invoke ("throwBomb", 1f);
	}
	
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
		
	void throwBomb() {

		//find monkey Object
		GameObject monkey = GameObject.Find ("Monkey");

		//if monkey exists
		if (monkey != null) {
			//put bomb in the scene
			GameObject newBomb = Instantiate(bomb);

			//set bomb position to enemy's postion
			newBomb.transform.position = transform.position;

			//set a vector pointing from the bomb(and enemy) to the monkey
			Vector2 direction = monkey.transform.position - newBomb.transform.position;

			//call bombScript with direction set
			newBomb.GetComponent<BombScript>().setDirection (direction);
		}
	}
	void OnTriggerEnter2D(Collider2D col) {
		//if the enemy gets collided with a gameObject with bananaTag
		if (col.tag == "bananaTag") {

			//instantiate the explosion
			ParticleSystem explosion1 = Instantiate (bananaBomb);
			ParticleSystem explosion2 = Instantiate (fireBomb);

			//play the explosion in the same position
			explosion1.transform.position = transform.position;
			explosion2.transform.position = transform.position;

			//destroy the gameObject
			Destroy (gameObject);
		}
	}
}
