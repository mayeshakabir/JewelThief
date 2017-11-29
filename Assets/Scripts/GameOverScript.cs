using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

	private Button[] buttons;

	void Awake(){
		
		// at the beginging get the buttons
		buttons = GetComponentsInChildren<Button>();

		// Disable the buttons
		HideButtons();
	}

	public void HideButtons() {

		//hide each button
		foreach (var b in buttons)
		{
			b.gameObject.SetActive(false);
		}
	}

	public void ShowButtons() {

		//show each button
		foreach (var b in buttons)
		{
			b.gameObject.SetActive(true);
		}
	}

	public void ExitToMenu() {
		
		// if pressed menu button change to menu scene
		Application.LoadLevel("menu");
	}

	public void RestartGame() {
		
		// if pressed restart button change to game scene
		Application.LoadLevel("scene.1");
	}
}
