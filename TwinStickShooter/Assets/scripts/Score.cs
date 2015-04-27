using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	public int score;
	public AnimationCurve frontalCurve, lateralCurve;
	public float frontalLoop, lateralLoop;
	public float velocidadFrontal, velocidadLateral;
	public float dragBreak = 0.2f;
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
		if (PlayerShip.playerPosition.x - transform.position.x < 5 && PlayerShip.playerPosition.y - transform.position.y < 5) {
			rigidbody2D.velocity = transform.up * frontalCurve.Evaluate (timer / frontalLoop) * velocidadFrontal + transform.right * lateralCurve.Evaluate (timer / lateralLoop) * velocidadLateral;
			rigidbody2D.velocity = rigidbody2D.velocity * dragBreak;
		} else {
			Vector3 dir = (PlayerShip.playerPosition - transform.position).normalized;
			Quaternion rot = Quaternion.LookRotation (Vector3.forward, dir);
			transform.rotation = Quaternion.Slerp (transform.rotation,rot, rotationSpeed*Time.deltaTime);
			velocidadFrontal = 60;
			rigidbody2D.velocity = transform.up *frontalCurve.Evaluate(timer/frontalLoop) *velocidadFrontal + transform.right *lateralCurve.Evaluate(timer/lateralLoop) *velocidadLateral ;
		}
	}
}
