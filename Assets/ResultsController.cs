using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsController : MonoBehaviour {

	public GameObject scoreObj;
	Text score;

	DataController dataController;

	// Use this for initialization
	void Start () {
		// Setup
		score = scoreObj.GetComponent<Text>();
		dataController = GameObject.FindGameObjectWithTag ("DataController").GetComponent<DataController> ();

		score.text = "Your Score: " + dataController.getScore ().ToString();
		print (dataController.getScore ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
