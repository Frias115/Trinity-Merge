using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {

	public GameObject[] waves;
	GameObject[] activeWave;
	int numberWave = 0;
	static float spawnTimer = 0;
	public float waitTime = 5;
	public int spawnsXWaves = 1;

	public UnityEngine.UI.Image fade;
	float fadeTimer = 0;
	public float fadeTime = 1;
	bool fadingOut = false;

	public UnityEngine.UI.Image fadeLevelInfo;
	float timeToFade = 0;
	public float fadingTime = 1;
	bool fadeOut = false;

	public float scoreTime = 1;
	public float scoreTimer = 0;
	bool scoreTimeStart = false;

	public UnityEngine.UI.Text highScoreList;



	// Use this for initialization
	void Start () {
		numberWave = 0;
		activeWave = new GameObject[spawnsXWaves];
		for(int i = 0; i < spawnsXWaves; i++)
		{
			activeWave[i] = Instantiate (waves[numberWave]) as GameObject;
			activeWave[i].SetActive (true);
			numberWave++;
		}
	}

	public int nextlevel;

	float deathFadeTimer = 0;
	float deathFadeTime =1;
	
	// Update is called once per frame
	void Update () {
		Debug.Log (numberWave);

		if (PlayerShip._healthPlayer == 0) {
			numberWave = 0;
			spawnsXWaves = 1;
			deathFadeTimer += Time.deltaTime;
			if(deathFadeTimer > deathFadeTime){
				fadingOut = true;
			}
			//
			highScoreList.transform.localPosition = new Vector3(1,1,1);
			if(Input.anyKeyDown)
			{
				Application.LoadLevel(0);
			}
			//
		}
		if (!fadingOut) {
			fadeTimer += Time.deltaTime;
			if (fadeTimer > fadeTime) {
				fadeTimer = fadeTime;
			}
		} else {
			fadeTimer -= Time.deltaTime;
			if (fadeTimer < 0) {
				fadeTimer = 0;
				if(PlayerShip._healthPlayer > 0){
					Application.LoadLevel (nextlevel);
				}else{
					//
					scoreTimeStart = true;
					//
				}
			}
		}
		fade.color = new Color (0,0,0, 1 - fadeTimer/fadeTime);
		if (fadeTimer == fadeTime) {
			
			timeToFade += Time.deltaTime;
			if (timeToFade > fadingTime) {
					timeToFade = fadingTime;
			}
			if(!fadingOut)
				fadeLevelInfo.color = new Color (1, 1, 1, 1 - timeToFade / fadingTime);

		} else {
			if(!fadingOut)
				fadeLevelInfo.color = new Color (1, 1, 1, fadeTimer/fadeTime);
		}
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
			fadeOut = true;

		}

	}
}
