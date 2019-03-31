using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;// Required when using Event data.

public class TileCollider : MonoBehaviour, IPointerEnterHandler {

	// Information about the tile
	private int id;
	private char data;
	private bool selected = false;

	private TextMesh tm;

	// References
	private GameController gc;

	// Use this for initialization
	void Start () {
		gc = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}

	void Awake() {
		tm = transform.GetChild (0).GetComponent<TextMesh> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	// Mouse over detection
	void OnMouseOver(){
		if (gc.pressed) {
			// print ("valid hover");
			gc.movementInterpretation (data, id);
		}
		//print ("hover");
	}

	// Check if the tile was clicked as last one
	void OnMouseUpAsButton(){
		int last = gc.getLastId ();
		if (last == -1) {
			// submitted sequence is empty
			return;
		}
		if (last == id) {
			gc.submitSequence ();
		}
	}

	//Do this when the cursor enters the rect area of this selectable UI object.
	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("The cursor entered the selectable UI element.");
	}

	public void setId(int id, char data){
		this.id = id;
		this.data = data;

		print(this.id);
		tm.text = data.ToString ();
	}
}
