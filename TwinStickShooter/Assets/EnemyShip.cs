using UnityEngine;
using System.Collections;

public class EnemyShip : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	
	public AnimationCurve frontalCurve, lateralCurve;
	public float frontalLoop, lateralLoop;
	public float velocidadFrontal, velocidadLateral;
	protected float timer = 0;

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		Move ();
	}

	public virtual void Move(){
		rigidbody2D.velocity = transform.up *frontalCurve.Evaluate(timer/frontalLoop) *velocidadFrontal + transform.right *lateralCurve.Evaluate(timer/lateralLoop) *velocidadLateral ;
	}
}
