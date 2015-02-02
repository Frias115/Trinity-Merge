using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public float velocidad;
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.up * velocidad * Time.deltaTime;
		if (transform.position.y > 30) {
			Destroy (this.gameObject);		
		}
	}

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.GetComponent<Enemy> () != null) {
			coll.gameObject.GetComponent<Enemy> ().Die();
			Destroy (this.gameObject);
		}
	}
}
