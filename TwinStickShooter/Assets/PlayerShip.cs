using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rigidbody2D.velocity = GameInput.ejeX * Vector2.right + GameInput.ejeY * Vector2.up;
		rigidbody2D.velocity.Normalize();
		rigidbody2D.velocity = rigidbody2D.velocity * maxSpeed;
	}
}
