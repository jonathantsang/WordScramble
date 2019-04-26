using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {

	// Used to store data on the game

	// Singleton
	public static DataController instance = null;
	WD wd;

	HashSet<string> wordsFound;
	int score = 0;

	// Use this for initialization
	void Start () {
		//Check if instance already exists
		if (instance == null)
			instance = this;
		else if (instance != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad(this.gameObject);

		// Look at the WordDictionary
		wd = new WD();

		wordsFound = new HashSet<string> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Public data
	public int getScore(){
		return score;
	}

	public bool addWord(string word){
		if (wordsFound.Contains (word)) {
			return false;
		} else {
			bool res = wd.checkWord (word);
			if (res) {
				// Add length - 2 points
				score += (word.Length - 2);
				print (score);
			}
			return res;
		}
	}
}
