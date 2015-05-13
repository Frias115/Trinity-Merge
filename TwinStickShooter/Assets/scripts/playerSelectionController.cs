using UnityEngine;
using System.Collections;

public class playerSelectionController : MonoBehaviour {
	
	public UnityEngine.UI.Text Tommy;
	public UnityEngine.UI.Text Fatu;
	public UnityEngine.UI.Text Gombon;
	UnityEngine.UI.Text selected;
	int movimientoCursor;
	public float fadeTime = .5f;
	float timer;
	float time = 0.25f;
	public float scaleMultiplier = 1.5f;
	public bool fadingOut = false;
	public AnimationCurve blinkCurve;

	public UnityEngine.UI.Image fade;
	float fadeBlackTimer = 0;
	public float fadeBlackTime = 1;
	
	// Use this for initialization
	void Start () {
		selected = Fatu;
		Tommy.CrossFadeColor (Color.white, fadeTime, true, false);
		Fatu.CrossFadeColor (Color.red, fadeTime, true, false);
		Gombon.CrossFadeColor (Color.white, fadeTime, true, false);
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (GameInput.ejeX > 0.5f && timer >time && !fadingOut) {
			movimientoCursor = 1;
			timer = 0;
		} else if (GameInput.ejeX < -0.5f && timer >time && !fadingOut) {
			movimientoCursor = -1;
			timer = 0;
		} else {
			movimientoCursor = 0;
		}
		
		if(Input.anyKeyDown && movimientoCursor == 0 && GameInput.ejeX == 0)
		{
			fadingOut = true;
			Application.LoadLevel(2);
		}

		if(selected.text == "FATU" && timer == time){
			Tommy.transform.localScale = Vector3.one;
			Fatu.transform.localScale = Vector3.one*(1 + scaleMultiplier *blinkCurve.Evaluate(timer));
			Gombon.transform.localScale = Vector3.one;
		}else if(selected.text == "GOMBON" && timer == time){
			Tommy.transform.localScale = Vector3.one;
			Fatu.transform.localScale = Vector3.one;
			Gombon.transform.localScale = Vector3.one*(1 + scaleMultiplier *blinkCurve.Evaluate(timer));
		}else if(selected.text == "TOMMY" && timer == time){
			Tommy.transform.localScale = Vector3.one *(1 + scaleMultiplier *blinkCurve.Evaluate(timer));
			Fatu.transform.localScale = Vector3.one;
			Gombon.transform.localScale = Vector3.one;
		}
		
		if (movimientoCursor == 1) {
			switch (selected.text) {
			case "FATU":
				Tommy.CrossFadeColor (Color.white, fadeTime, true, false);
				Fatu.CrossFadeColor (Color.white, fadeTime, true, false);
				Gombon.CrossFadeColor (Color.red, fadeTime, true, false);
				selected = Gombon;
				break;
			case "TOMMY":
				Tommy.CrossFadeColor (Color.white, fadeTime, true, false);
				Fatu.CrossFadeColor (Color.red, fadeTime, true, false);
				Gombon.CrossFadeColor (Color.white, fadeTime, true, false);
				selected = Fatu;
				break;
			case "GOMBON":
				Tommy.CrossFadeColor (Color.red, fadeTime, true, false);
				Fatu.CrossFadeColor (Color.white, fadeTime, true, false);
				Gombon.CrossFadeColor (Color.white, fadeTime, true, false);
				selected = Tommy;
				break;
			default:

				break;
			}
		} else if (movimientoCursor == -1) {
			switch (selected.text) {
			case "FATU":
				Tommy.CrossFadeColor (Color.red, fadeTime, true, false);
				Fatu.CrossFadeColor (Color.white, fadeTime, true, false);
				Gombon.CrossFadeColor (Color.white, fadeTime, true, false);
				selected = Tommy;
				break;
			case "TOMMY":
				Tommy.CrossFadeColor (Color.white, fadeTime, true, false);
				Fatu.CrossFadeColor (Color.white, fadeTime, true, false);
				Gombon.CrossFadeColor (Color.red, fadeTime, true, false);
				selected = Gombon;
				break;
			case "GOMBON":
				Tommy.CrossFadeColor (Color.white, fadeTime, true, false);
				Fatu.CrossFadeColor (Color.red, fadeTime, true, false);
				Gombon.CrossFadeColor (Color.white, fadeTime, true, false);
				selected = Fatu;
				break;
			default:
				
				break;
			}
		}

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



