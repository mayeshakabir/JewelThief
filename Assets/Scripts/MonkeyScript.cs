using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonkeyScript : MonoBehaviour {

	public GameObject banana; //give it the gameObject varible
	public ParticleSystem bananaBomb;
	public ParticleSystem fireBomb;

	public int health = 3;
	public Text LivesText;

	public int score = 0;
	public Text ScoreText;

	public float speed = 10f;

	// Use this for initialization
	void Start () {
		LivesText.text = health.ToString ();
		ScoreText.text = score.ToString ();
	}
	
	// Update is called once per frame
	void Update () {

		//getting position with which button
		//returns -1 - 1, on which pos/neg button you press
		float xAxis = Input.GetAxis("Horizontal");
		float yAxis = Input.GetAxis("Vertical");

		//Movement with what button direction * speed I want * Time.deltaTime to make it run per second
		Vector2 movement = new Vector2(xAxis, yAxis) * speed * Time.deltaTime;

		//the movement
		transform.Translate (movement);
		

		if (Input.GetKeyDown("space")) {
			//put whatever gameObject varible (banana) in the scene at the postion of current gameObject (monkey (transform.pos))
			Instantiate(banana, transform.position, Quaternion.identity);
		}

		//bounds
		var dist = (transform.position - Camera.main.transform.position).z;

		var left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		var right = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
		var top = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
		var bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, left, right),
			Mathf.Clamp(transform.position.y, top, bottom),
			transform.position.z);
	}

	void OnTriggerEnter2D(Collider2D col) {

		//if the monkey gets collided with a gameObject with jewelTag
		if (col.tag == "jewelTag1") {
			score += 5;
			ScoreText.text = score.ToString ();
		} else if( col.tag == "jewelTag2") {
			score += 3;
			ScoreText.text = score.ToString ();
		} else if( col.tag == "jewelTag3") {
			score += 1;
			ScoreText.text = score.ToString ();
		}

		//if the monkey gets collided with a gameObject with enemyTag or bombTag
		if ((col.tag == "enemyTag") || (col.tag == "bombTag")) {

			//instantiate the explosion
			ParticleSystem explosion0 = Instantiate (bananaBomb);

			//play the explosion in the same position
			explosion0.transform.position = transform.position;

			//decrease health
			health--;
			LivesText.text = health.ToString ();

			if (health == 0) {

				//instantiate the explosion
				ParticleSystem explosion1 = Instantiate (bananaBomb);
				ParticleSystem explosion2 = Instantiate (fireBomb);

				//play the explosion in the same position
				explosion1.transform.position = transform.position;
				explosion2.transform.position = transform.position;

				//destroy the gameObject
				//call game over
				Destroy (gameObject);

				//show the menu and restart buttons
				var gameOver = FindObjectOfType<GameOverScript>();
				gameOver.ShowButtons();
			}
		}
	}
}
