using UnityEngine;
using System.Collections;

public class BackgroundAnimations : MonoBehaviour {

	private float contador;

	public Transform target;

	public float intervalo;
	public float rotationSpeed;
	public float scalationSpeed;
	public float translationSpeed;
	public float verticalSpeed;
	public AnimationCurve rotation;
	public AnimationCurve scalation;
	public AnimationCurve translation;
	public bool lookAttarget;

	Transform myTransform;
	Vector3 originalScale;
	// Use this for initialization
	void Start () {
		myTransform = transform;
		originalScale = myTransform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		contador += Time.deltaTime;
		//transform.Rotate (Vector2.right * Time.deltaTime*rotationSpeed);
		//transform.position += -Vector3.up * Time.deltaTime * verticalSpeed;
		if(lookAttarget)
			myTransform.LookAt(target);
		if(scalationSpeed > 0)
			myTransform.localScale = originalScale * scalation.Evaluate (contador/scalationSpeed);
	}
}

//Tu sabes que pasa cuando viene el coco?
//Tu sabes???


