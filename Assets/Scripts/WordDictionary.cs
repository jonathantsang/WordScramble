using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class WordDictionary : MonoBehaviour {
	void Start(){
		WD worddict = new WD ();
		worddict.readWords ();
		print ("done reading words");
	}

	void Update(){
	
	}
}

public class WD {
	public Dictionary<string, int> words = new Dictionary<string, int> ();

	public void readWords() {
		string path = "Assets/Resources/words_alpha.txt";

		//Read the text from directly from the test.txt file
		StreamReader reader = new StreamReader(path); 

		string word = "";
		while (word != null) {
			word = reader.ReadLine ();
			if (word == null) {
				break;
			}
			words [word] = 1;
		}

		reader.Close();
	}

	public bool checkWord(string word){
		if (words.ContainsKey(word)){
			return true;
		}
		return false;
	}

}