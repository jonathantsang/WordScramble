using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private GameObject Board;
	public GameObject tile;

	// Used in player input
	bool pressed = false;

	// Use this for initialization
	void Start () {
		Board = GameObject.FindGameObjectWithTag ("Board").gameObject;

		createBoard (Board);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void createBoard(GameObject Board){
		int width = 4;
		int height = 4;
		for (int i = 0; i < height; i++) {
			for (int j = 0; j < width; j++) {
				GameObject obj = Instantiate (tile, new Vector3((j-width/2) * 2, (i-height/2) * 2, 0), Quaternion.identity);
				obj.transform.parent = Board.transform.parent;
			}
		}
	}


}
