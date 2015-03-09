using UnityEngine;
using System.Collections;

public class BackgroundAnimations : MonoBehaviour {
	public int rotationSpeed;
	public int scalationSpeed;
	public int translationSpeed;
	public AnimationCurve rotation;
	public AnimationCurve scalation;
	public AnimationCurve translation;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector2.right * Time.deltaTime*rotationSpeed);
	}
}
