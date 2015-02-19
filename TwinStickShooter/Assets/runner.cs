using UnityEngine;
using System.Collections;

public class runner : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	
	public AnimationCurve frontalCurve, lateralCurve;
	public float frontalLoop, lateralLoop;
	public float velocidadFrontal, velocidadLateral;
	float timer = 0;
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		rigidbody2D.velocity = Vector2.up *frontalCurve.Evaluate(timer/frontalLoop) *velocidadFrontal + Vector2.right *lateralCurve.Evaluate(timer/lateralLoop) *velocidadLateral ;
		
	}
}
