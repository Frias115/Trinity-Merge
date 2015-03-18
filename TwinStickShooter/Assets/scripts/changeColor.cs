using UnityEngine;
using System.Collections;

public class changeColor : MonoBehaviour {


	public Color[] colors;
	public float tiempoDeCadaColor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.renderer.material.color = colors [Random.Range (0, colors.Length)];
	}

	void OnTriggerEnter(Collider other){
		gameObject.renderer.material.color = colors [Random.Range (0, colors.Length)];
	}
}
