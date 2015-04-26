using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public ParticleSystem powerUp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		powerUp.Play ();
	
	}
}
