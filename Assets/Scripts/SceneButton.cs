using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour {

	public string nextScene;
	private Button btn;


	// Use this for initialization
	void Start () {
		btn = GetComponent<Button> ();
		btn.onClick.AddListener (changeScene);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void changeScene(){
		SceneManager.LoadScene(nextScene);
	}
}
