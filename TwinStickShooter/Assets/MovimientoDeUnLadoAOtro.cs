using UnityEngine;
using System.Collections;

public class MovimientoDeUnLadoAOtro : MonoBehaviour {


	public Vector3 pointB;
	
	IEnumerator Start()
	{
		var pointA = transform.position;
		while (true) {
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
		}
	}
	
	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		var i= 0.0f;
		var rate= 1.0f/time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}


}














//public float velocidadDeMovimiento;
//public float TiempoDeMovimiento;
//bool onPlay;

// Use this for initialization
//void Start () {
//	onPlay = true;
//}

// Update is called once per frame
//void Update () {
//	if (onPlay) {
//		onPlay = false;
//		transform.Translate(Vector3.down * Time.deltaTime * velocidadDeMovimiento, Vector3.right * Time.deltaTime * velocidadDeMovimiento, 0, Space.World);
//		if (Time.time > TiempoDeMovimiento)
//		{
//			onPlay = true;
//		}
//	}
//}