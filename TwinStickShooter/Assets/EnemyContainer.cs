using UnityEngine;
using System.Collections;

public class EnemyContainer : MonoBehaviour {

	ParticleSystem p;
	public GameObject enemy;
	// Use this for initialization
	void Start () {
		p = GetComponent<ParticleSystem> ();
		p.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!p.isPlaying) {
			enemy.transform.parent = null;
			enemy.SetActive(true);
			Destroy (this.gameObject);
		}
	}
}
