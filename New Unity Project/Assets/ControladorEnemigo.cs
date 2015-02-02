using UnityEngine;
using System.Collections;

public class ControladorEnemigo : MonoBehaviour {

	public static ControladorEnemigo _instance;

	static bool change = false;
	static bool goingRight = true;


	// Use this for initialization
	void Start () {
		_instance = this;
	}
	
	// Update is called once per frame
	public float horizontalSpeed;
	public float verticalSpeed;
	public float downDistance = 2;


	void Update () {
		if (change) {
			transform.position += -Vector3.up * Time.deltaTime * verticalSpeed; 
			if (transform.position.y <= previousY - downDistance) {
				transform.position = new Vector3 (transform.position.x, previousY - downDistance, transform.position.z);
				change = false;
				goingRight = !goingRight;
			}
		} else {
			Vector3 direction = Vector3.right;
			if(!goingRight)
				direction = -direction;
			transform.position += direction * Time.deltaTime * horizontalSpeed; 
		}
	}

	static float previousY;

	public void ChangeDirection(float x){
		if (!change && goingRight && x >= 10) {
			change = true;
			previousY = transform.position.y;
		} else if (!change && !goingRight && x <= -10) {
			change = true;
			previousY = transform.position.y;
		}
	}
}
