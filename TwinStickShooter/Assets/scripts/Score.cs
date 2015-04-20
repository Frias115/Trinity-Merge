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
		rigidbody2D.velocity = (transform.up *frontalCurve.Evaluate(timer/frontalLoop) *velocidadFrontal + transform.right *lateralCurve.Evaluate(timer/lateralLoop) *velocidadLateral) * dragBreak ;
	}
}
