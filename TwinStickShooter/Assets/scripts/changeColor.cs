using UnityEngine;
using System.Collections;



public class changeColor : MonoBehaviour {

	float nextUsage;
	public Color[] colors;

	public float tiempoDeCadaColor;
	// Use this for initialization
	void Start () {
		nextUsage = Time.time + tiempoDeCadaColor;
	}
	
	// Update is called once per frame
	void Update () {

		if(Time.time > nextUsage)
		{
			nextUsage = Time.time + tiempoDeCadaColor;
			gameObject.renderer.material.color = colors [Random.Range (0, colors.Length)];
		}

	}


}




