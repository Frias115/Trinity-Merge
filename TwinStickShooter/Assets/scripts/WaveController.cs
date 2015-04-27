using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {

	public GameObject[] waves;
	//GameObject activeWave;
	GameObject[] activeWave;
	int numberWave = 0;
	static float spawnTimer = 0;
	public float waitTime = 5;
	public int spawnsXWaves = 1;

	public UnityEngine.UI.Image fade;
	float fadeTimer = 0;
	public float fadeTime = 1;
	bool fadingOut = false;

	// Use this for initialization
	void Start () {
		activeWave = new GameObject[spawnsXWaves];
		for(int i = 0; i < spawnsXWaves; i++)
		{
			activeWave[i] = Instantiate (waves[numberWave]) as GameObject;
			activeWave[i].SetActive (true);
			numberWave++;
		}
	}

	public int nextlevel;
	
	// Update is called once per frame
	void Update () {
		if (!fadingOut) {
			fadeTimer += Time.deltaTime;
			if (fadeTimer > fadeTime) {
				fadeTimer = fadeTime;
			}
		} else {
			fadeTimer -= Time.deltaTime;
			if (fadeTimer < 0) {
				fadeTimer = 0;
				Application.LoadLevel (nextlevel);
			}
		}
		fade.color = new Color (0,0,0, 1 - fadeTimer/fadeTime);
		/*
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
		*/

		if (SpawnController.enemigosRestantes ==  0 && numberWave < waves.Length) {
			spawnTimer +=  Time.deltaTime;
			if(spawnTimer > waitTime){
				for(int i = 0; i < spawnsXWaves; i++)
				{
					Destroy (activeWave[i]);
				}
				if (numberWave < waves.Length){
					activeWave = new GameObject[spawnsXWaves];
					for(int i = 0; i < spawnsXWaves; i++)
					{
						activeWave[i] = Instantiate (waves[numberWave]) as GameObject;
						activeWave[i].SetActive (true);
						numberWave++;
					}
				}
				spawnTimer = 0;
			}
			
		}else if(SpawnController.enemigosRestantes ==  0){
			fadingOut = true;
		}

	}
}
