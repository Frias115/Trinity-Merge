using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour {
	
	public float maxSpeed = 0.5f;
	public float dragInInput = 0.1f;
	public float dragLateral = 0.5f;
	public float dragBreak = 0.2f;
	public float aceleracionInDirection = 5f;
	public float aceleracionInOppositeDir = 10f;
	public static Vector3 playerPosition;
	public GameObject bala;
	public float rotationInterpolation = 0.5f;
	public float timeBetweenShots = 0.5f;
	float shotTimer = 0;
	public int _healthPlayer = 1;
	public int _damagePlayer = 1;
	public ParticleSystem deathExplosion; 
	public ParticleSystem shootParticle;
	public ParticleSystem powerUp;
	public ParticleSystem powerUp02;

	public AudioSource source;
	public AudioSource deathSource;
	public AudioClip shotSound;
	public AudioClip explosionSound;


	public void PlaySound (AudioClip c) {
		source.PlayOneShot (c);
	}
	
	public void PlayDeathSound (AudioClip c) {
		deathSource.PlayOneShot (c);
	}


	// Use this for initialization
	void Start () {
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		shotTimer += Time.deltaTime;
		Vector2 input= GameInput.ejeX * Vector2.right + GameInput.ejeY * Vector2.up;
		Vector2 vel = rigidbody2D.velocity;
		if (input.magnitude < 0.2f || vel.magnitude < 1f) {
			vel = vel * dragBreak;
		} else {
			Vector2 velA = input.normalized * Mathf.Cos(Mathf.Deg2Rad*Vector2.Angle (input, vel))*vel.magnitude;
			Vector2 velB = input.normalized * Mathf.Sin(Mathf.Deg2Rad*Vector2.Angle (vel,input))*vel.magnitude;
			velB = new Vector2(-velB.y,velB.x);
			velA = velA * dragInInput;
			velB = velB * dragLateral;
			vel = velA + velB;
			input.Normalize();
		}
		if (Vector2.Angle (vel, input) < 90) {
			input *= aceleracionInDirection;
		} else {
			input *= aceleracionInOppositeDir;
		}
		rigidbody2D.velocity = vel + input ; 

		//Diparo jugador
		Vector2 firingDirection = Vector2.right*GameInput.ejeXDisparo + Vector2.up*GameInput.ejeYDisparo;
		if (firingDirection.magnitude >= 0.5f && shotTimer >= timeBetweenShots) {
			GameObject baladisparada = (GameObject)Instantiate (bala, bala.transform.position, bala.transform.rotation); 
			baladisparada.transform.parent = null;
			baladisparada.SetActive (true);
			shootParticle.Play ();
			PlaySound (shotSound);
			while(shotTimer >= timeBetweenShots)
				shotTimer -= timeBetweenShots;
		}

		//Posicion jugador
		playerPosition = transform.position;
		CheckPowerUp ();
		CheckPowerUp02 ();

	}


	void OnCollisionEnter2D (Collision2D col)
	{
		PlayerShip player = col.gameObject.GetComponent<PlayerShip> ();
		if(player != null)
		{
			player.Damage(this._damagePlayer);
			Destroy(gameObject);
		}
		if(col.gameObject.GetComponent<PowerUp>()){
			powerUpTimer = 0;
			if(!powerUpped){
				timeBetweenShots = timeBetweenShots/pu_shotTimeFactor;
				bala.transform.localScale = bala.transform.localScale*pu_SizeFactor;
			}
			powerUpped = true;
			powerUp.Play ();
			Destroy(col.gameObject);
		}
		if(col.gameObject.GetComponent<PowerUp02>()){
			powerUpTimer = 0;
			if(!powerUpped) {
				aceleracionInDirection = aceleracionInDirection / pu_velocityFactor;
			}
			powerUpped = true;
			powerUp02.Play ();
			Destroy (col.gameObject);
		}

	}
		
	public void Damage(int damage)
	{
		_healthPlayer -= damage;
		CameraMovement.Shake ();
		CameraMovement.HitStop ();
		if (_healthPlayer <= 0) {
			deathExplosion.Play();
			deathExplosion.transform.parent = null;
			PlayDeathSound (explosionSound);
			Destroy(this.gameObject);

		}
	}

	
	bool powerUpped = false;
	float powerUpTime = 5;
	float powerUpTimer = 0;
	float pu_shotTimeFactor = 3;
	float pu_SizeFactor = 2;
	float pu_velocityFactor = 0.3f;

	void CheckPowerUp(){
		powerUpTimer += Time.deltaTime;
		if (powerUpTimer > powerUpTime) {
			if(powerUpped){
				timeBetweenShots = timeBetweenShots*pu_shotTimeFactor;
				bala.transform.localScale = bala.transform.localScale/ pu_SizeFactor;
				powerUpped = false;
			}
		}
	}

	void CheckPowerUp02() {
		powerUpTimer += Time.deltaTime;
		if (powerUpTimer > powerUpTime) {
			if (powerUpped) {
				aceleracionInDirection = aceleracionInDirection * pu_velocityFactor;
				powerUpped = false;
			}
		}
	}

		
	void Update(){
		Vector2 firingDirection = Vector2.right * GameInput.ejeXDisparo + Vector2.up * GameInput.ejeYDisparo;
		if (firingDirection.magnitude > 0.5f) {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Vector3.forward, firingDirection), rotationInterpolation * Time.deltaTime);
		}
	}
	
}
