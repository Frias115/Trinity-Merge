using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {
	
	public Transform[] spawnPoint;
	public GameObject Enemy;
	public static int enemigosRestantes = 0;
	
	// Use this for initialization
	void Start () {
		foreach (Transform child in spawnPoint) {
			Instantiate (Enemy, child.position, child.rotation);
			enemigosRestantes++;
		}
	}
	
	// Update is called once per frame
	void Update () {
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