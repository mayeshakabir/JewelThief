using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnJewelScript : MonoBehaviour {

	public GameObject jewelToSpawn1;
	public GameObject jewelToSpawn2;
	public GameObject jewelToSpawn3;
	float rate1 = 20f;
	float rate2 = 15f;
	float rate3 = 3f;

	// Use this for initialization
	void Start () {

		Invoke ("Spawn1", rate1);
		Invoke ("Spawn2", rate2);
		Invoke ("Spawn3", rate3);

	}

	// Update is called once per frame
	void Update () {

	}

	void Spawn1() {

		//top right
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1,1));

		//bottom right
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0));

		GameObject jewel1 = (GameObject)Instantiate (jewelToSpawn1);

		jewel1.transform.position = new Vector2 (Random.Range((max.x + 3f), (max.x + 30f)), Random.Range(min.y, max.y));

		NextSpawn ("type1");

	}

	void Spawn2() {
		
		//top right
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1,1));

		//bottom right
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0));

		GameObject jewel2 = (GameObject)Instantiate (jewelToSpawn2);

		jewel2.transform.position = new Vector2 (Random.Range((max.x + 3f), (max.x + 30f)), Random.Range(min.y, max.y));

		NextSpawn ("type2");

	}

	void Spawn3() {

		//top right
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1,1));

		//bottom right
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0));

		GameObject jewel3 = (GameObject)Instantiate (jewelToSpawn3);

		jewel3.transform.position = new Vector2 (Random.Range((max.x + 3f), (max.x + 10f)), Random.Range(min.y, max.y));

		NextSpawn ("type3");

	}

	void NextSpawn(string spawnType) {

		float newRate1;
		float newRate2;
		float newRate3;

		if (spawnType == "type1") {
			if (rate1 > 16f) {
				newRate1 = Random.Range (16f, rate1);
			} else
				newRate1 = 16f;

			Invoke("Spawn1", newRate1);
		}
		else if (spawnType == "type2") {
			if (rate2 > 10f) {
				newRate2 = Random.Range (10f, rate2);
			} else
				newRate2 = 10f;

			Invoke("Spawn2", newRate2);
			
		}
		else if (spawnType == "type3"){
			if (rate3 > 1f) {
				newRate3 = Random.Range (1f, rate3);
			} else
				newRate3 = 1f;

			Invoke("Spawn3", newRate3);
			
		}
	}
}
