using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {

	public int timerLength;

	private GameController gameController;
	private Text timer;

	// Use this for initialization
	void Start () {
		timer = GameObject.FindGameObjectWithTag ("Timer").GetComponent<Text> ();
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		StartCoroutine (runTimer());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator runTimer(){
		for (int i = 0; i <= timerLength; i++) {
			// Update the timer
			int left = timerLength - i;

			int mins = left / 60;
			int secs = left % 60;
			string minpart = mins.ToString ();
			string secspart = secs.ToString ();

			if (secspart.Length == 1) {
				secspart = "0" + secspart;
			}

			timer.text = minpart + ":" + secspart;
			// Wait
			yield return new WaitForSecondsRealtime (1);
		}

		// Notify done the game
		gameController.endGame();
	}
}
