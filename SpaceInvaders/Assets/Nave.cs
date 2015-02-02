using UnityEngine;
using System.Collections;

public class Nave : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public float velocidadnave;
	public GameObject bala;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			transform.position += - Vector3.right*velocidadnave*Time.deltaTime; 		
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.position += Vector3.right*velocidadnave*Time.deltaTime; 		
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject baladisparada = (GameObject)Instantiate (bala, bala.transform.position, bala.transform.rotation); 
			baladisparada.SetActive (true);
		}

		float x = Mathf.Clamp (transform.position.x, -10, 10);
		transform.position = new Vector3 (x, transform.position.y,transform.position.z);
	
	}
}
