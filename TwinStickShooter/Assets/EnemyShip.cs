﻿using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {

	public int score = 100;
	public AnimationCurve frontalCurve, lateralCurve;
	public float frontalLoop, lateralLoop;
	public float velocidadFrontal, velocidadLateral;
	protected float timer = 0;
	public float timeBetweenShots = 0.5f;
	protected float shotTimer = 0;
	public GameObject balaEnemigo;
	public int healthEnemy = 1;
	public static int damageEnemy = 1;


	// Use this for initialization
	void Start () {

	}



	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		Move ();
		Shoot ();
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		PlayerShip player = col.gameObject.GetComponent<PlayerShip> ();
		if(player != null)
		{
			player.Damage(EnemyShip.damageEnemy);
		}
		Destroy(gameObject);
	}

	public virtual void Damage(int damage)
	{
		healthEnemy -= damage;
		if (healthEnemy <= 0) {
			Destroy(this.gameObject);
		}
	}


	public virtual void Move(){
		rigidbody2D.velocity = transform.up *frontalCurve.Evaluate(timer/frontalLoop) *velocidadFrontal + transform.right *lateralCurve.Evaluate(timer/lateralLoop) *velocidadLateral ;
	}

	public virtual void Shoot(){
		
		shotTimer += Time.deltaTime + timeBetweenShots;
		if (shotTimer >= 4 && balaEnemigo != null) {
			GameObject baladisparada = (GameObject)Instantiate (balaEnemigo, balaEnemigo.transform.position, balaEnemigo.transform.rotation); 
			baladisparada.SetActive (true);
			shotTimer = 0;
		}

	}
}
