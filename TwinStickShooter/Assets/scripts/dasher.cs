using UnityEngine;
using System.Collections;

public class dasher : EnemyShip {
	
	public float rotationSpeed = 100;
	
	public override void Move(){

	}

	public override void Dash()
	{
		do {
			dashTimer += Time.deltaTime;
			Vector3 dir = (PlayerShip.playerPosition - transform.position).normalized;
			Quaternion rot = Quaternion.LookRotation (Vector3.forward, dir);
			transform.rotation = Quaternion.Slerp (transform.rotation, rot, rotationSpeed * Time.deltaTime);
			rigidbody2D.velocity = transform.up * frontalCurve.Evaluate (timer / frontalLoop) * velocidadFrontal + transform.right * lateralCurve.Evaluate (timer / lateralLoop) * velocidadLateral;
		} while(dashTimer < timeBetweenDash);
		dashTimer = 0;
	}

}

