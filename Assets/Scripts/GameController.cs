using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	Text wordsCollection;

	// Used in player input
	public bool pressed = false;
	private List<tilePair> selectedCharacters = new List<tilePair> (); // Pair of (character, id)

	DataController datacontroller;

	// Use this for initialization
	void Start () {
		Board = GameObject.FindGameObjectWithTag ("Board").gameObject;
		datacontroller = GameObject.FindGameObjectWithTag ("DataController").GetComponent<DataController> ();
		wordsCollection = GameObject.FindGameObjectWithTag ("WordsCollection").GetComponent<Text> ();

		createBoard (Board);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			pressed = true;
		} else {
			pressed = false;
			// selectedCharacters.Clear (); // Released, not necessarily clear if individual tap for the selected characters
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
				int id = i * height + j;

				// Weighted with vowels
				// 97, 101, 105, 111, 117 ~121
				// a    e   i    o     u    y
				int weight = Random.Range(0, 4);
				char c = (char) Random.Range (97, 122);

				char[] vowels = new char[] {'a', 'e', 'i', 'o', 'u'};
				// Change to vowel
				if (weight == 0) {
					int rd = Random.Range(0, 4);
					c = vowels[rd];
				}


				// tc.setId (i * height + j, (char)('a'+ i * height + j)); // For now just c, will do random
				tc.setId (id, c);
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

		// Check if it CAN be added, in 8 directions around the tile

		// Is the id in the selectedCharacters? If it is truncate the selectedCharacters
		for (int i = 0; i < selectedCharacters.Count; i++) {
			if (selectedCharacters[i].idx == id && selectedCharacters[i].c == c){
				// Truncate it here
				print("found truncate");

				// Have to set the highlights correctly
				for(int j = i; j < selectedCharacters.Count; j++){
					int turnoffidx = selectedCharacters [j].idx;
					Board.transform.GetChild (turnoffidx).GetComponent<TileCollider> ().setHighlight (false);
				}

				selectedCharacters  = selectedCharacters.GetRange (0, i);
				return;
			}
		}
		// Add to the end
		addToSelectedCharacters(c, id);
		Board.transform.GetChild (id).GetComponent<TileCollider> ().setHighlight (true);
		printSelectedCharacters ();
	}

	// Submits the sequence for "processing"
	public void submitSequence(){
		// For now we clear it
		print("submitted");
		printSelectedCharacters ();

		// Form word
		string word = "";
		foreach (tilePair tp in selectedCharacters) {
			word += tp.c.ToString ();
		}

		// Submit to DataController
		bool res = datacontroller.addWord(word);

		// res will tell us if it is valid or not
		print("It is " + res + " trying to add word: " + word);

		// Update side word stats
		if (res) {
			if (wordsCollection == null) {
				wordsCollection = GameObject.FindGameObjectWithTag ("WordsCollection").GetComponent<Text> ();
			}
			wordsCollection.text += "\n" + word;
		}

		selectedCharacters.Clear();
		// Clear highlights
		// TODO fix 16 tiles
		for(int i = 0; i < 16; i++){
			Board.transform.GetChild (i).GetComponent<TileCollider> ().setHighlight (false);
		}

		pressed = false; // Set for now so it doesn't set path again
	}

	public int getLastId(){
		if (selectedCharacters.Count == 0){
			return -1;
		}
		return selectedCharacters [selectedCharacters.Count-1].idx;
	}

	void printSelectedCharacters(){
		string ans = "";
		string word = "";
		foreach (tilePair tp in selectedCharacters) {
			ans += "( " + tp.c.ToString () + " " + tp.idx.ToString () + " )" + " ";
			word += tp.c.ToString ();
		}
		print (word);
		print (ans);
	}

	// Public methods
	public void endGame(){
		// Called by the timer
		SceneManager.LoadScene("Results");
	}

}
