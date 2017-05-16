using UnityEngine;
using System.Collections;

public class robot : MonoBehaviour {
	public Plane path;
	public float speed=20.0f;
	public float mass=5.0f;
	public bool looping=true;

	private float botSpeed;
	private int PathIndex;
	private float PathLength;
	private Vector3 targetPosition;
	private Vector3 botVelocity;
	public Vector3 Accelerate(Vector3 target){
		Vector3 desiredVelocty = target - transform.position;
		
		desiredVelocty.Normalize ();
		desiredVelocty *= botSpeed;
		
		Vector3 steeringForce = desiredVelocty - botVelocity;
		Vector3 acceleration = steeringForce / mass;
		return acceleration;
	}
	// Use this for initialization
	void Start () {
		PathLength = path.Length;
		PathIndex = 0;
		botVelocity = transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
		botSpeed = speed * Time.deltaTime;
		targetPosition = path.GetPosition (PathIndex);

		if (Vector3.Distance (transform.position, targetPosition) < path.Radius) {
			if(PathIndex < PathLength-1)
				PathIndex++;
			else if(looping)
				PathIndex=0;
			else return;


        }
		botVelocity += Accelerate (targetPosition);
		transform.position += botVelocity;
		transform.rotation = Quaternion.LookRotation (botVelocity);
	}

}
