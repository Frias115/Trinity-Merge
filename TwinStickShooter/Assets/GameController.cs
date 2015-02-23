using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static UnityEngine.UI.Text scoreText;
	public  UnityEngine.UI.Text _scoreText;
	public static int score = 0;

	// Use this for initialization
	void Start () {
		scoreText = _scoreText;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void AddScore(){
		PlayerShip.score += enemy.score;
		PlayerShip.scoreText.text = "Score: " + PlayerShip.score;
	}
	
}
