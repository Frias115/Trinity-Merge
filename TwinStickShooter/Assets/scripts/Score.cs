using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		rigidbody2D.velocity = transform.up * velocidadFrontal;
	}
	
	public int score;
	public float velocidadFrontal;
	float dragBreak = 0.9f;
	float distFollow =  15;
	public float rotationSpeed = 1000;

	float timer = 0;
	
	// Update is called once per frame
	
	
	void OnCollisionEnter2D (Collision2D col)
	{
		PlayerShip player = col.gameObject.GetComponent<PlayerShip> ();
		if(player != null)
		{
			GameController.AddScore(score);
		}
		Destroy(this.gameObject);
	}


	
	
	void FixedUpdate () {
		timer += Time.deltaTime;
		if ((transform.position - PlayerShip.playerPosition).magnitude > distFollow) {
			rigidbody2D.velocity = rigidbody2D.velocity * dragBreak;
		} else {
			Vector3 dir = (PlayerShip.playerPosition - transform.position).normalized;
			Quaternion rot = Quaternion.LookRotation (Vector3.forward, dir);
			transform.rotation = Quaternion.Slerp (transform.rotation,rot, rotationSpeed*Time.deltaTime);
			velocidadFrontal = 60;
			rigidbody2D.velocity = transform.up *velocidadFrontal + transform.right ;
		}
	}
}
