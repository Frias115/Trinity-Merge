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
		nextUsage = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
//		if (Time.time > nextUsage) {
//			nextUsage = Time.time + tiempoDeCadaColor;
//			gameObject.renderer.material.color = Color.Lerp (color1, color2, lerpTime);
//		} else {nextUsage = Time.time + tiempoDeCadaColor;
//			gameObject.renderer.material.color = Color.Lerp (color2, color1, lerpTime);}

		nextUsage += Time.deltaTime;
		if (nextUsage > tiempoDeCadaColor) {
			float transitionTime = nextUsage - tiempoDeCadaColor;
			if(transitionTime > lerpTime){
				nextUsage = transitionTime - lerpTime;
				Color c = color1;
				color1 = color2;
				color2 = c;
				foreach(Renderer r in this.GetComponentsInChildren<Renderer>()){
					r.material.color = c;
				}
			}else{
				foreach(Renderer r in this.GetComponentsInChildren<Renderer>()){
					r.material.color = Color.Lerp (color2, color1, transitionTime/lerpTime);
				}
			}
		}
	}
	
	
}
