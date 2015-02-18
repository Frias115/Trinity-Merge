using UnityEngine;
using System.Collections;

public class follower : EnemyShip {

	public float rotationSpeed = 100;
	
	public override void Move(){
		Vector3 dir = (PlayerShip.playerPosition - transform.position).normalized;
		Quaternion rot = Quaternion.LookRotation (Vector3.forward, dir);
		transform.rotation = Quaternion.Slerp (transform.rotation,rot, rotationSpeed*Time.deltaTime);
		base.Move ();
	}
}
