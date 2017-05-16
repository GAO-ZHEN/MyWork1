using UnityEngine;
using System.Collections;

public class Plane : MonoBehaviour {
	public bool showpath=true;
	public Color pathColor=Color.red;
	public bool loop=true;
	public float Radius=2.0f;
	public Transform[] wayPoint;
	// Use this for initialization
	void Reset(){
		wayPoint = new Transform[GameObject.FindGameObjectsWithTag ("wayPoint").Length];
		
		for (int cnt=0; cnt<wayPoint.Length; cnt++) {
			wayPoint[cnt]=GameObject.Find("wayPoint_"+(cnt+1).ToString()).transform;
		}
	}
	public float Length{
		get{
			return wayPoint.Length;
		}
	}
	public Vector3 GetPosition(int index){
		return wayPoint [index].position;
	}
	void OnDrawGizmos(){
		if (!showpath)return;

		for (int i=0; i<wayPoint.Length; i++) {
			if(i+1<wayPoint.Length){
				Debug.DrawLine(wayPoint[i].position,wayPoint[i+1].position,pathColor);
			}
			else{
				if(loop){
					Debug.DrawLine(wayPoint[i].position,wayPoint[0].position,pathColor);
				}
			}
		}
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
