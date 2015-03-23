using UnityEngine;
using System.Collections;

public class MovimientoDeUnLadoAOtro : MonoBehaviour {

	public Transform pointToGoTo;
	 Vector3 pointB;
	Vector3 pointA;
	public float velocidadDeMovimiento;
	public float TiempoDeMovimiento;
	
	void Start()
	{
		pointA = transform.localPosition;
	}

	float timer;
	bool backwards = false;

	void Update () {
		if (backwards) {
				timer -= Time.deltaTime;
				if (timer < 0) {
						timer = 0;
						backwards = false;
				}
		} else {
				timer += Time.deltaTime;
				if (timer > TiempoDeMovimiento) {
						timer = TiempoDeMovimiento;
						backwards = true;
				}
		}
		transform.localPosition = Vector3.Lerp (pointA, pointToGoTo.localPosition, timer/TiempoDeMovimiento);
	}


}















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