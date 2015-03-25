using UnityEngine;
using System.Collections;

public class rotator : MonoBehaviour {

	// Use this for initialization
	public float rotationX;
	public float rotationY;
	public float rotationZ;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (rotationX * Time.deltaTime, rotationY * Time.deltaTime, rotationZ * Time.deltaTime));
	}
}
