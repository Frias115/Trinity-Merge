using UnityEngine;
using System.Collections;

public class dasher : EnemyShip {
	
	public float rotationSpeed = 100;
	
	public override void Move(){

	}

	public override void Dash()
	{
		if (dashTimer < timeBetweenDash) {
			dashTimer += Time.deltaTime;
			Vector3 dir = (PlayerShip.playerPosition - transform.position).normalized;
			Quaternion rot = Quaternion.LookRotation (Vector3.forward, dir);
			transform.rotation = Quaternion.Slerp (transform.rotation, rot, rotationSpeed * Time.deltaTime);
			rigidbody2D.velocity = Vector2.zero;
		} else if (dashTimer > timeBetweenDash + timeInDash) {
			dashTimer = 0;
		} else {
			dashTimer += Time.deltaTime;
			rigidbody2D.velocity = transform.up * frontalCurve.Evaluate ((dashTimer - timeBetweenDash)/ timeInDash) * velocidadFrontal + transform.right * lateralCurve.Evaluate (timer / lateralLoop) * velocidadLateral;

		}
	}

}

