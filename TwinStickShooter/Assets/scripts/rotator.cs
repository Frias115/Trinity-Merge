using UnityEngine;
using System.Collections;

public class rotator : MonoBehaviour {

	// Use this for initialization
	public float rotationX;
	public float rotationY;
	public float rotationZ;

	Rigidbody2D body;
	void Start () {
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!body) {
			transform.Rotate (new Vector3 (rotationX * Time.deltaTime, rotationY * Time.deltaTime, rotationZ * Time.deltaTime));
		} else {
		}
	}

	
	void FixedUpdate () {
		if (!body) {
		} else {
			body.WakeUp();
			body.rotation += rotationZ * Time.deltaTime;		
		}
	}
}
