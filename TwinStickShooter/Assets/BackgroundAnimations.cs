using UnityEngine;
using System.Collections;

public class BackgroundAnimations : MonoBehaviour {
	private float contador;
	public int intervalo;
	public int rotationSpeed;
	public int scalationSpeed;
	public int translationSpeed;
	public float verticalSpeed;
	public AnimationCurve rotation;
	public AnimationCurve scalation;
	public AnimationCurve translation;
	// Use this for initialization
	void Start () {
		contador += Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector2.right * Time.deltaTime*rotationSpeed);
		//transform.position += -Vector3.up * Time.deltaTime * verticalSpeed;
	}
}



