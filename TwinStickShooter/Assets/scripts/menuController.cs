using UnityEngine;
using System.Collections;

public class menuController : MonoBehaviour {

	public UnityEngine.UI.Text pressStart;
	public UnityEngine.UI.Text highScoresButton;
	public UnityEngine.UI.Text gameStartButton;
	public UnityEngine.UI.Text highScoreList;
	bool showingHighScoers = false;
	float HighsCoreTimer = 0;
	float timer = 0;
	public AnimationCurve blinkCurve;
	public float fadeTime = .5f;
	float fadeTimer = 0;
	public float scaleMultiplier = 1.5f;

	
	public UnityEngine.UI.Image fade;
	float fadeBlackTimer = 0;
	public float fadeBlackTime = 1;
	bool fadingOut = false;

	public UnityEngine.UI.Text selected ;

	// Use this for initialization
	void Start () {
		selected = pressStart;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (selected == pressStart || showingHighScoers) {
			fadeTimer -= Time.deltaTime;
			if (fadeTimer < 0)
				fadeTimer = 0;
			if(Input.anyKeyDown && !showingHighScoers){
				selected = gameStartButton;
				gameStartButton.CrossFadeColor(Color.red,fadeTime,true,false);
			}
		} else {
			fadeTimer += Time.deltaTime;
			if (fadeTimer > fadeTime)
				fadeTimer = fadeTime;
			if((GameInput.ejeX >0.5f || GameInput.ejeX < -0.5f) && timer > fadeTime && !showingHighScoers){
				timer = 0;
				if(selected == gameStartButton){
					selected = highScoresButton;
					gameStartButton.CrossFadeColor(Color.white,fadeTime,true,false);
					highScoresButton.CrossFadeColor(Color.red,fadeTime,true,false);
				}else{
					selected = gameStartButton;
					highScoresButton.CrossFadeColor(Color.white,fadeTime,true,false);
					gameStartButton.CrossFadeColor(Color.red,fadeTime,true,false);
				}
			}
		}
		if(!showingHighScoers)
			pressStart.color = new Color(1,1,1,blinkCurve.Evaluate(timer)* (1 - fadeTimer/fadeTime));
		highScoresButton.color = new Color(1,1,1,fadeTimer/fadeTime);
		gameStartButton.color = new Color(1,1,1,fadeTimer/fadeTime);

		if(selected == gameStartButton && fadeTimer == fadeTime){
			gameStartButton.transform.localScale = Vector3.one*(1 + scaleMultiplier *blinkCurve.Evaluate(timer));
			highScoresButton.transform.localScale = Vector3.one;
			if(Input.anyKeyDown )
			{
				fadingOut = true;
			}
		}else if(selected == highScoresButton){
			if(Input.anyKeyDown ){
				if(!showingHighScoers)
					showingHighScoers = true;
				else{
					showingHighScoers = false;
				}
			}
			highScoresButton.transform.localScale = Vector3.one*(1 + scaleMultiplier*blinkCurve.Evaluate(timer));
			gameStartButton.transform.localScale = Vector3.one;
		}

		if (showingHighScoers) {
			HighsCoreTimer += Time.deltaTime;
			if (HighsCoreTimer > fadeTime)
				HighsCoreTimer = fadeTime;
		} else {
			HighsCoreTimer -= Time.deltaTime;
			if (HighsCoreTimer < 0)
				HighsCoreTimer = 0;
		}


		highScoreList.transform.localPosition = new Vector3(0,- Screen.height  + Screen.height*HighsCoreTimer/fadeTime*0.8f,0);

		
		if (!fadingOut) {
			fadeBlackTimer += Time.deltaTime;
			if (fadeBlackTimer > fadeBlackTime) {
				fadeBlackTimer = fadeBlackTime;
			}
		} else {
			fadeBlackTimer -= Time.deltaTime;
			if (fadeBlackTimer < 0) {
				fadeBlackTimer = 0;
				Application.LoadLevel (1);
			}
		}
		fade.color = new Color (0,0,0, 1 - fadeBlackTimer/fadeBlackTime);
	}
}
