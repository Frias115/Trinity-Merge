using UnityEngine;
using System.Collections;

public class BalaEsfera : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	
	public AnimationCurve frontalCurveSphere, lateralCurveSphere;
	public float frontalLoopSphere, lateralLoopSphere;
	
	
	public float velocidadFrontalSphere, velocidadLateralSphere;
	
	float timerSphere = 0;
	// Update is called once per frame
	void FixedUpdate () {
		timerSphere += Time.deltaTime;
		rigidbody2D.velocity = Vector2.up *frontalCurveSphere.Evaluate(timerSphere/frontalLoopSphere) *velocidadFrontalSphere + Vector2.right *lateralCurveSphere.Evaluate(timerSphere/lateralLoopSphere) *velocidadLateralSphere ;

	}
}