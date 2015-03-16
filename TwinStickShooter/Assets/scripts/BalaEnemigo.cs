using UnityEngine;
using System.Collections;

public class BalaEnemigo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public int damage;
	public AnimationCurve frontalCurve, lateralCurve;
	public float frontalLoop, lateralLoop;
	public float velocidadFrontal, velocidadLateral;
	public int _healthEnemyBullet = 1;
	public ParticleSystem deathExplosion;
	
	float timer = 0;
	
	// Update is called once per frame
	
	
	void OnCollisionEnter2D (Collision2D col)
	{
		PlayerShip player = col.gameObject.GetComponent<PlayerShip> ();
		if(player != null)
		{
			player.Damage(damage);
		}
		Explode ();
	}

	public void Explode()
	{
		if (deathExplosion != null) {
			deathExplosion.Play();
			deathExplosion.transform.parent = null;
		}
		Destroy(this.gameObject);
	}
	
	
	void FixedUpdate () {
		timer += Time.deltaTime;
		rigidbody2D.velocity = transform.up *frontalCurve.Evaluate(timer/frontalLoop) *velocidadFrontal + transform.right *lateralCurve.Evaluate(timer/lateralLoop) *velocidadLateral ;
	}
}
