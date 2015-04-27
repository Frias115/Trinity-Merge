using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static UnityEngine.UI.Text scoreText;
	public  UnityEngine.UI.Text _scoreText;
	public static UnityEngine.UI.Image chainTimerText;
	public  UnityEngine.UI.Image _chainTimerText;
	public static int score = 0;
	static int chain = 1;
	static float chainTimer = 0;
	static float maxChainTime = 1.5f;

	// Use this for initialization
	void Start () {
		scoreText = _scoreText;
		chainTimerText = _chainTimerText;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate () {
		if (chain > 1) {
			CheckChain();
		}
		chainTimerText.fillAmount = 1 - chainTimer/maxChainTime;
		Debug.Log (chain);
	}

	public static void CheckChain (){
		chainTimer += Time.deltaTime;
		if(chainTimer > maxChainTime)
		{
			chainTimer = 0;
			ResetChain();
		}
	}

	public static void AddChain (){
		chain++;
		if (chain > 6)
			chain = 6;
		chainTimer = 0;
	}

	public static void ResetChain (){
		chain = 1;
		chainTimer = 0;
	}

	public static void AddScore(int scoreValue){
		chainTimer = 0;
		score += scoreValue * chain;
		scoreText.text = "" + score;
		ScoreShower.Show (scoreValue,chain,PlayerShip.playerPosition);
	}
	
}
