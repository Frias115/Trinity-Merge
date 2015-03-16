using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {
	
	public Transform[] spawnPoint;
	public GameObject Enemy;
	// Use this for initialization
	void Start () {
		foreach (Transform child in spawnPoint) {
			Instantiate(Enemy, child.position,child.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
