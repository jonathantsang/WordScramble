using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour {

	public static SaveController instance;

	float counter = 0;
	float limit = 0.75f;

	// Use this for initialization
	void Start () {
		// Singleton Behaviour
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
		DontDestroyOnLoad(gameObject);


		Load ();
	}
	
	// Update is called once per frame
	void Update () {
		if (counter >= limit) {
			Save ();
			counter = 0;
		}
		counter += Time.deltaTime;
	}

	public void Save(){
		SaveLoadManager.SaveData ();
	}

	public void Load(){
		SaveData loadedStats = SaveLoadManager.LoadData ();

		// Load from stats
		// print(loadedStats.Currency);
		// print (loadedStats.Collected);
		// IC.LoadInventory (loadedStats.Collected, loadedStats.RecipesUnlocked, loadedStats.Stats, loadedStats.ShopUnlocked, loadedStats.Currency);

		// Loads data
		// print(loadedStats);
	}
}
