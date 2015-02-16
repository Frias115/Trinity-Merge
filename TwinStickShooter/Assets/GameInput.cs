using UnityEngine;
using System.Collections;

public class GameInput : MonoBehaviour {

	static public float ejeX;
	static public float ejeY;
	static public float ejeXDisparo;
	static public float	ejeYDisparo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ejeX = Input.GetAxis ("Horizontal");
		ejeY = Input.GetAxis ("Vertical");
		ejeXDisparo = Input.GetAxis ("HorizontalAim");
		ejeYDisparo = Input.GetAxis ("VerticalAim");
	}
}
