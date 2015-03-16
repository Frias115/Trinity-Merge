using UnityEngine;
using System.Collections;

[RequireComponent(typeof (LineRenderer))]
[RequireComponent(typeof (EdgeCollider2D))]
[ExecuteInEditMode]
public class Level : MonoBehaviour {

	public Transform[] pointArray;
	public bool forceUpdate;
	public EdgeCollider2D colliderEdge;
	LineRenderer line;

	// Use this for initialization
	void Start () {
		CreateMap();
	}
	
	// Update is called once per frame
	void Update () {
		if (line == null) {
			line = GetComponent<LineRenderer>();		
		}
		if (colliderEdge == null) {
			colliderEdge = GetComponent<EdgeCollider2D>();		
		}
		if(forceUpdate){
			forceUpdate = false;
			CreateMap();
		}
		UpdateMap ();
	}

	void CreateMap(){
		line.SetVertexCount (pointArray.Length + 1);
		colliderEdge.Reset ();
		Vector2[] points =  new Vector2[pointArray.Length + 1];
		for (int i = 0; i < pointArray.Length; i++) {
			line.SetPosition (i,pointArray[i].position);
			points[i] = new Vector2(pointArray[i].localPosition.x,pointArray[i].localPosition.y);
		}
		line.SetPosition (pointArray.Length, pointArray [0].position);
		points[pointArray.Length] = new Vector2(pointArray[0].localPosition.x,pointArray[0].localPosition.y);
		colliderEdge.points = points;
	}

	
	void UpdateMap(){
		Vector2[] points =  new Vector2[pointArray.Length + 1];
		for (int i = 0; i < pointArray.Length; i++) {
			line.SetPosition (i,pointArray[i].position);	
			points[i] = new Vector2(pointArray[i].localPosition.x,pointArray[i].localPosition.y);
		}
		line.SetPosition (pointArray.Length, pointArray [0].position);
		points[pointArray.Length] = new Vector2(pointArray[0].localPosition.x,pointArray[0].localPosition.y);
		colliderEdge.points = points;
	}
}
