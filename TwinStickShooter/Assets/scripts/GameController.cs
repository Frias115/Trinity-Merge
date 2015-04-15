using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static UnityEngine.UI.Text scoreText;
	public  UnityEngine.UI.Text _scoreText;
	public static int score = 0;
	static int cadena = 1;
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
		if (cadena > 1) {
			CheckChain();
		}
		Debug.Log (cadena);
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
		cadena++;
	}

	public static void ResetChain (){
		cadena = 1;
	}

	public static void AddScore(int enemyValue){
		score += enemyValue;
		scoreText.text = "Score: " + score;
	}
	
}
