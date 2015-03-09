using UnityEngine;
using System.Collections;

public class runner : EnemyShip {

	public float rotationSpeed = 100;
	
	public override void Move(){
		Vector3 dir = (PlayerShip.playerPosition - transform.position).normalized;
		Quaternion rot = Quaternion.LookRotation (Vector3.forward, dir);
		transform.rotation = Quaternion.Slerp (transform.rotation,rot, rotationSpeed*Time.deltaTime);
		base.Move ();
	}
	/*
	public override void Move () {
		float rushFrontal, rushLateral;
		bool rush;
		//rigidbody2D.velocity = Vector2.up *frontalCurve.Evaluate(timer/frontalLoop) *velocidadFrontal + Vector2.right *lateralCurve.Evaluate(timer/lateralLoop) *velocidadLateral;
		if(!rush) {
			rigidbody2D.velocity = Vector2.up * velocidadFrontal + Vector2.right * velocidadLateral;
			if(enemyPositionY == PlayerShip.playerPositionY || enemyPositionX == PlayerShip.playerPositionX)
			{
				rush = true;
			}
		}
		else
		{
			if (enemyPositionX < PlayerShip.playerPositionX) 
			{
				rigidbody2D.velocity = Vector2.right * rushLateral;
			}
			else if (enemyPositionX > PlayerShip.playerPositionX)
			{
				rigidbody2D.velocity = Vector2.right * -rushLateral;
			}
		}
	}*/
}
