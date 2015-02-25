using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}


	public AnimationCurve frontalCurve, lateralCurve;
	public float frontalLoop, lateralLoop;
	
	
	public float velocidadFrontal, velocidadLateral;

	float timer = 0;

	// Update is called once per frame


		void OnCollisionEnter2D (Collision2D col)
		{
			EnemyShip enemy = col.gameObject.GetComponent<EnemyShip> ();
			if(enemy != null)
			{

				GameController.AddScore(enemy.score);
				
				enemy.Damage(PlayerShip.damagePlayer);
			}
			Destroy(gameObject);
		}


	void FixedUpdate () {
		timer += Time.deltaTime;
		rigidbody2D.velocity = transform.up *frontalCurve.Evaluate(timer/frontalLoop) *velocidadFrontal + transform.right *lateralCurve.Evaluate(timer/lateralLoop) *velocidadLateral ;
		if (transform.position.z > 30) {
			Destroy (this.gameObject);		
		}
	}
}
