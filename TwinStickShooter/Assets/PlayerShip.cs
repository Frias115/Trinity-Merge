using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour {

	public float maxSpeed = 0.5f;
	public float dragInInput = 0.1f;
	public float dragLateral = 0.5f;
	public float aceleracionInDirection = 5f;
	public float aceleracionInOppositeDir = 10f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 input= GameInput.ejeX * Vector2.right + GameInput.ejeY * Vector2.up;
		Vector2 vel = rigidbody2D.velocity;
		Vector2 velA = Vector2.Project (vel,input);
		Vector2 velB = vel - velA;
		velA = velA * dragInInput;
		velB = velB * dragLateral;
		Vector2 velFinal = velA + velB;
		input.Normalize();
		if (Vector2.Angle (velFinal, input) < 90) {
			input *= aceleracionInDirection;
		} else {
			
			input *= aceleracionInOppositeDir;
		}
		rigidbody2D.velocity = velFinal + input ;
	}
}
