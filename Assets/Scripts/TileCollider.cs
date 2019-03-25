using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;// Required when using Event data.

public class TileCollider : MonoBehaviour, IPointerEnterHandler {

	bool selected = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Mouse
	void OnMouseDown(){
		// Set game to pressed
		//print ("clicked");
	}

	void OnMouseOver(){
		//print ("hover");
	}

	//Do this when the cursor enters the rect area of this selectable UI object.
	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("The cursor entered the selectable UI element.");
	}
}
