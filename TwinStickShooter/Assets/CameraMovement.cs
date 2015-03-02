using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public float movementInterpolation = 1;
	public float rotationInterpolation = 1;

	static bool shaking = false;

	public float shakeAmm = 0.1f;
	public float shakeTime = 0.5f;
	static float shakeTimer = 0;
	public float slowDown = 0.1f;
	public float slowDownTime = 0.5f;
	static float slowDownTimer = 0;
	static bool slowing = false;


	// Update is called once per frame
	void Update () {
		Vector3 desiredPos = PlayerShip.playerPosition / 1.25f;
		transform.position = Vector3.Lerp (transform.position, new Vector3(desiredPos.x, desiredPos.y, transform.position.z), movementInterpolation * Time.deltaTime);
		Vector3 lookDir = PlayerShip.playerPosition - transform.position;
		transform.rotation =Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (lookDir, Vector3.up), rotationInterpolation * Time.deltaTime);
		if (shaking) {
			Vector3 rand = Random.insideUnitSphere * shakeAmm;
			rand = new Vector3 (rand.x, rand.y, 0);
			transform.position += rand;
			shakeTimer += Time.deltaTime;
			if (shakeTimer > shakeTime) {
				shakeTimer = 0;
				shaking = false;
			}
		}

		if (slowing) {
			Time.timeScale = slowDown;
			slowDownTimer += Time.deltaTime;
			if (slowDownTimer > slowDownTime) {
				slowDownTimer = 0;
				slowing = false;
			}
		} else {
			Time.timeScale = 1.0f;
		}
	}

	public static void Shake (){
		shaking = true;
		shakeTimer = 0;
	}

	public static void HitStop (){
		slowing = true;
		slowDownTimer = 0;
	}
}
