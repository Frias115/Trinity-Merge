using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {

	public AnimationCurve frontalCurve, lateralCurve;
	public float frontalLoop, lateralLoop;
	public float velocidadFrontal, velocidadLateral;
	protected float timer = 0;
	public float timeBetweenShots = 0.5f;
	public float timeInDash = 1.5f;
	public float timeBetweenDash = 1.5f;
	protected float shotTimer = 0;
	protected float dashTimer = 0;
	public GameObject balaEnemigo;
	public GameObject explosionEnemigo;
	public int healthEnemy = 1;
	public int damageEnemy = 1;
	public ParticleSystem deathExplosion;
	public EnemyShip []hijos;
	public GameObject score;



	// Use this for initialization
	void Start () {

	}



	// Update is called once per frame
	void FixedUpdate () {
		timer += Time.deltaTime;
		Move ();
		Shoot ();
		Dash ();
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		PlayerShip player = col.gameObject.GetComponent<PlayerShip> ();
		if(player != null)
		{
			player.Damage(this.damageEnemy);
			if(hijos != null)
			{
				foreach(EnemyShip hijo in hijos)
				{
					hijo.transform.parent = null;
					hijo.gameObject.SetActive(true);
				}
			}
			Destroy(gameObject);
		}
	}

	public virtual void Damage(int damage)
	{
		healthEnemy -= damage;
		if (healthEnemy <= 0) {
			CameraMovement.Shake ();
			CameraMovement.HitStop ();
			GameController.AddChain();
			Explode ();

			if (score != null) {
				score.SetActive (true);
				score.transform.parent = null;
			}

			if(deathExplosion != null){
				deathExplosion.Play();
				deathExplosion.transform.parent = null;
			}



			if(hijos != null)
			{
				foreach(EnemyShip hijo in hijos)
				{
					SpawnController.enemigosRestantes++;
					hijo.transform.parent = null;
					hijo.gameObject.SetActive(true);
				}
			}
			SpawnController.enemigosRestantes--;
			Destroy (this.gameObject);
		}
	}

	public virtual void Explode(){
		if (explosionEnemigo != null) {
			explosionEnemigo.SetActive (true);
			explosionEnemigo.transform.parent = null;
		}
	}

	public virtual void Dash()
	{

	}


	public virtual void Move(){
		rigidbody2D.velocity = transform.up *frontalCurve.Evaluate(timer/frontalLoop) *velocidadFrontal + transform.right *lateralCurve.Evaluate(timer/lateralLoop) *velocidadLateral ;
	}

	public virtual void Shoot(){
		shotTimer += Time.deltaTime;
		if (shotTimer > timeBetweenShots && balaEnemigo != null) {
			GameObject baladisparada = (GameObject)Instantiate (balaEnemigo, balaEnemigo.transform.position, balaEnemigo.transform.rotation); 
			baladisparada.SetActive (true);
			shotTimer = 0;
		}

	}
}
