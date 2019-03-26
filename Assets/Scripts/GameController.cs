using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// Struct for storing tile information
	struct tilePair {
		public char c;
		public int idx;

		public tilePair(char c, int idx){
			this.c = c;
			this.idx = idx;
		}
	}

	private GameObject Board;
	public GameObject tile;

	// Used in player input
	public bool pressed = false;
	private List<tilePair> selectedCharacters = new List<tilePair> ();

	// Use this for initialization
	void Start () {
		Board = GameObject.FindGameObjectWithTag ("Board").gameObject;

		createBoard (Board);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			pressed = true;
		} else {
			pressed = false;
			selectedCharacters.Clear (); // Released, not necessarily clear if individual tap for the selected characters
		}
	}

	// Setup
	void createBoard(GameObject Board){
		int width = 4;
		int height = 4;
		float tilew = 1.6f;
		float tileh = 1.6f;
		for (int i = 0; i < height; i++) {
			for (int j = 0; j < width; j++) {
				GameObject obj = Instantiate (tile, new Vector3((j-width/2)*tilew, (i-height/2)*tileh, 0f), Quaternion.identity);
				TileCollider tc = obj.GetComponent<TileCollider> ();
				tc.setId (i * height + j, (char)('a'+ i * height + j)); // For now just c, will do random
				obj.transform.parent = Board.gameObject.transform;
			}
		}
	}

	// Usage
	void addToSelectedCharacters(char c, int id){
		tilePair tp = new tilePair(c, id);
		selectedCharacters.Add (tp);
	}

	// Moves off of a character to either:
	// 1. a previous one, where we remove the recent one and the one it goes to
	// 2. a new one and we append it
	public void movementInterpretation(char c, int id){
		// Check if (c, id) is at the end, just return
		if (selectedCharacters.Count > 0 && selectedCharacters[selectedCharacters.Count-1].idx == id 
			&& selectedCharacters[selectedCharacters.Count-1].c == c){
			return;
		} 

		// Is the id in the selectedCharacters? If it is truncate the selectedCharacters
		for (int i = 0; i < selectedCharacters.Count; i++) {
			if (selectedCharacters[i].idx == id && selectedCharacters[i].c == c){
				// Truncate it here
				print("found truncate");
				selectedCharacters  = selectedCharacters.GetRange (0, i);
				return;
			}
		}
		// Add to the end
		addToSelectedCharacters(c, id);
		printSelectedCharacters ();
	}

	List<tilePair> getSelectedCharacters(){
		return selectedCharacters;
	}

	void printSelectedCharacters(){
		string ans = "";
		foreach (tilePair tp in selectedCharacters) {
			ans += "( " + tp.c.ToString () + " " + tp.idx.ToString () + " )" + " ";
		}
		print(ans);
	}

}
