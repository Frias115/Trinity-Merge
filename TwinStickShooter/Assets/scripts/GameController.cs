using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static UnityEngine.UI.Text scoreText;
	public  UnityEngine.UI.Text _scoreText;
	public static int score = 0;
	static int chain = 1;
	static float chainTimer = 0;
	static float maxChainTimer = 4.0f;

	// Use this for initialization
	void Start () {
		scoreText = _scoreText;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate () {
		if (chain > 1) {
			CheckChain();
		}
		Debug.Log (chain);
	}

	public static void CheckChain (){
		chainTimer += Time.deltaTime;
		if(chainTimer > maxChainTimer)
		{
			chainTimer = 0;
			ResetChain();
		}
	}

	public static void AddChain (){
		chain++;
		chainTimer = 0;
	}

	public static void ResetChain (){
		chain = 1;
		chainTimer = 0;
	}

	public static void AddScore(int scoreValue){
		chainTimer = 0;
		score += scoreValue * chain;
		scoreText.text = "Score: " + score;
	}
	
}
