﻿using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {

	public GameObject[] waves;
	GameObject activeWave;
	int numberWave = 0;
	static float spawnTimer = 0;
	public float waitTime = 5;

	// Use this for initialization
	void Start () {
		activeWave = Instantiate (waves[numberWave]) as GameObject;
		activeWave.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (SpawnController.enemigosRestantes ==  0 && numberWave < waves.Length) {
			spawnTimer +=  Time.deltaTime;
			if(spawnTimer > waitTime){
				Destroy (activeWave);
				numberWave++;
				if (numberWave < waves.Length){
					activeWave = Instantiate (waves[numberWave]) as GameObject;
					activeWave.SetActive (true);
				}
				spawnTimer = 0;
			}
			
		}

	}
}
