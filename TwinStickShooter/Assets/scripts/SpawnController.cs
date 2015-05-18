using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SpawnController : MonoBehaviour {
	
	public Transform[] spawnPoint;
	public GameObject Enemy;
	public static int enemigosRestantes = 0;
	
	// Use this for initialization
	void Start () {
		if (Application.isPlaying) {
				foreach (Transform child in spawnPoint) {
						Instantiate (Enemy, child.position, child.rotation);
						enemigosRestantes++;
				}
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (enemigosRestantes);
		if (Application.isEditor) {
			foreach(Transform g in spawnPoint){
				Debug.DrawLine(g.position + Vector3.up, g.position - Vector3.up,Color.green);
				Debug.DrawLine(g.position + Vector3.right, g.position - Vector3.right,Color.green);
			}
			
			Debug.DrawLine(transform.position + Vector3.up, transform.position - Vector3.up,Color.red);
			Debug.DrawLine(transform.position + Vector3.right, transform.position - Vector3.right,Color.red);
		}
		/*
		if (enemigosRestantes ==  0) {
			spawnTimer +=  Time.deltaTime;
			if(spawnTimer > waitTime){
				foreach (Transform child in spawnPoint) {
					Instantiate (Enemy, child.position, child.rotation);
					enemigosRestantes++;
				}
				spawnTimer = 0;
			}
		}
		*/
	}
}