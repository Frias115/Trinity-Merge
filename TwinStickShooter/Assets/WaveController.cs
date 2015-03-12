using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {

	public GameObject[] waves;
	int numberWave = 0;
	static float spawnTimer = 0;
	public float waitTime = 5;

	// Use this for initialization
	void Start () {
		waves [numberWave].SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (SpawnController.enemigosRestantes ==  0 && numberWave < waves.Length) {
			spawnTimer +=  Time.deltaTime;
			if(spawnTimer > waitTime){
				waves [numberWave].SetActive (false);
				numberWave++;
				waves [numberWave].SetActive (true);
				spawnTimer = 0;
			}
			
		}

	}
}
