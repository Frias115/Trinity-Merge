using UnityEngine;
using System.Collections;

public class ParticleEliminator : MonoBehaviour {


	ParticleSystem p;
	bool played = false;
	// Use this for initialization
	void Start () {
		p = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!played ) {
			if(p.isPlaying){
				played = true;
			}
		}else if(!p.isPlaying){
			Destroy (this.gameObject);
		}
	}
}
