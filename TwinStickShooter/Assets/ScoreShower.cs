using UnityEngine;
using System.Collections;

public class ScoreShower : MonoBehaviour {



	public ParticleSystem score20;
	public ParticleSystem score50;
	public ParticleSystem score100;
	public ParticleSystem score150;
	public ParticleSystem chainx1;
	public ParticleSystem chainx2;
	public ParticleSystem chainx4;
	public ParticleSystem chainx8;
	public ParticleSystem chainx16;
	public ParticleSystem chainx32;

	public static ScoreShower _instance;

	void Start(){
		_instance = this;
	}

	public static void Show(int score, int chain, Vector3 position){
		_instance.transform.position = position;
		switch (score) {
		case 20:
			_instance.score20.Play ();
			break;
		case 50:
			_instance.score50.Play ();
			break;
		case 100:
			_instance.score100.Play ();
			break;
		case 150:
			_instance.score150.Play ();
			break;
		default:
			break;
		}
		
		switch (chain) {
		case 1:
			_instance.chainx1.Play ();
			break;
		case 2:
			_instance.chainx2.Play ();
			break;
		case 3:
			_instance.chainx4.Play ();
			break;
		case 4:
			_instance.chainx8.Play ();
			break;
		case 5:
			_instance.chainx16.Play ();
			break;
		case 6:
			_instance.chainx32.Play ();
			break;
		default:
			break;
		}
	}
}
