using UnityEngine;
using System.Collections;

public class GameInput : MonoBehaviour {

	static float ejeX;
	static float ejeY;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ejeX = Input.GetAxis ("Horizontal");
		ejeY = Input.GetAxis ("Vertical");
	}
}
