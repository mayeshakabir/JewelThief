using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyScript : MonoBehaviour {

	public GameObject enemyToSpawn;
	float rate = 3f;

	// Use this for initialization
	void Start () {

		Invoke ("Spawn", rate);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn() {

		//top right
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1,1));

		//bottom right
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0));

		GameObject enemy = (GameObject)Instantiate (enemyToSpawn);
		enemy.transform.position = new Vector2 (Random.Range(max.x, (max.x + 10f)), Random.Range(min.y, max.y));

		NextSpawn ();

	}

	void NextSpawn() {

		float newRate;

		if (rate > 0.5f) {
			//is rate is > 1, pick a random number of 1-5 to randomize
			newRate = Random.Range (0.5f, rate);
		} else
			newRate = 0.5f;

		Invoke("Spawn", newRate);
	}
}
