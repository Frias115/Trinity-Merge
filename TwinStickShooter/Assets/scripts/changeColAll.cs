using UnityEngine;
using System.Collections;



public class changeColAll : MonoBehaviour {
	
	float nextUsage;
	float firstUsage;
	public Color color1;
	public Color color2;
	public float lerpTime;

	public float tiempoDeCadaColor;
	// Use this for initialization
	void Start () {
		nextUsage = Time.time + tiempoDeCadaColor;
		firstUsage = nextUsage / 2;
	}
	
	// Update is called once per frame
	void Update () {
		
//		if (Time.time > nextUsage) {
//			nextUsage = Time.time + tiempoDeCadaColor;
//			gameObject.renderer.material.color = Color.Lerp (color1, color2, lerpTime);
//		} else {nextUsage = Time.time + tiempoDeCadaColor;
//			gameObject.renderer.material.color = Color.Lerp (color2, color1, lerpTime);}

		if (Time.time > firstUsage) {
			gameObject.renderer.material.color = Color.Lerp (color1, color2, lerpTime);
		} else if (Time.time > nextUsage){
			nextUsage = Time.time + tiempoDeCadaColor;
			firstUsage = nextUsage/2;
			gameObject.renderer.material.color = Color.Lerp (color2, color1, lerpTime);}
		}
	}
	
	
//}
