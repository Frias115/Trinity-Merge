using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	float startingY;
	float timer = 0;
	public float bounceSpeed = 5;
	public float deathSpeed = 1;
	float minimumY = -5;
	// Use this for initialization
	void Start () {
		startingY = transform.localPosition.y;
	}

	public AnimationCurve upDownCurve;
	public AnimationCurve scaleCurve;
	public AnimationCurve deathCurve;
	public AnimationCurve scaleDeathCurve;
	public float rotationSpeed = 5;

	bool dead = false;

	// Update is called once per frame
	void Update () {
		if (!dead) {
			timer += Time.deltaTime * bounceSpeed;
			ControladorEnemigo._instance.ChangeDirection (this.transform.position.x);
			transform.localPosition = new Vector3 (transform.localPosition.x, startingY + upDownCurve.Evaluate (timer), transform.localPosition.z);
			transform.localScale = new Vector3 (1, scaleCurve.Evaluate (timer), 1);
			transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y + Time.deltaTime*rotationSpeed, transform.localEulerAngles.z);
		} else {
			timer += Time.deltaTime * deathSpeed;
			transform.localPosition = new Vector3 (transform.localPosition.x, startingY + deathCurve.Evaluate (timer), transform.localPosition.z);
			transform.localScale = new Vector3 (1, scaleDeathCurve.Evaluate (timer), 1);
		}
		if(transform.position.y < minimumY){
			Destroy(this);
		}
	}
	public void Die(){
		dead = true;
		transform.parent = null;
		collider.enabled = false;
		timer = 0;
		startingY = transform.localPosition.y;
	}
}
