using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour {

	public float maxSpeed = 0.5f;
	public float dragInInput = 0.1f;
	public float dragLateral = 0.5f;
	public float dragBreak = 0.2f;
	public float aceleracionInDirection = 5f;
	public float aceleracionInOppositeDir = 10f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 input= GameInput.ejeX * Vector2.right + GameInput.ejeY * Vector2.up;
		Vector2 vel = rigidbody2D.velocity;
		if (input.magnitude < 0.2f || vel.magnitude < 1f) {
			vel = vel * dragBreak;
		} else {
			Vector2 velA = input.normalized * Mathf.Cos(Mathf.Deg2Rad*Vector2.Angle (input, vel))*vel.magnitude;
			Vector2 velB = input.normalized * Mathf.Sin(Mathf.Deg2Rad*Vector2.Angle (vel,input))*vel.magnitude;
			velB = new Vector2(-velB.y,velB.x);
			velA = velA * dragInInput;
			velB = velB * dragLateral;
			vel = velA + velB;
		}
		input.Normalize();
		if (Vector2.Angle (vel, input) < 90) {
			input *= aceleracionInDirection;
		} else {
			
			input *= aceleracionInOppositeDir;
		}
		rigidbody2D.velocity = vel + input ;
	}
}
