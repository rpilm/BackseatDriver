using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	float throttle=0f;
	float steer=0f;
	public float turnSpeed = 30;
	public float speed = 160; 
	public float antiSlip = 100.0f;
	
	Transform destination;
	
	//Pathfinder pathfinder; 
	
	void Start () {
		//Debug.Log (transform.forward);
		
		//GameObject pathfinderGameobject = GameObject.Find ("PathfindingManager");
		//pathfinder = pathfinderGameobject.GetComponent<Pathfinder>();
		
		GetNewDestination();
	}
	
	void Update () {
		GetInput ();
	}

	// use this for rigidbody physics updates
	void FixedUpdate () {

		ApplyFriction ();
		ApplyThrottle ();
		ApplySteering ();

	}

	void GetInput() {
		throttle = Input.GetAxis ("Vertical");
		steer = Input.GetAxis ("Horizontal");

	}

	// 
	void ApplyFriction ()
	{
		Vector3 relativeVelocity = transform.InverseTransformDirection(rigidbody.velocity);

		// apply sideways friction to prevent slipping

		float sqrVel = relativeVelocity.x * relativeVelocity.x;


		Vector3 antiSlipVecLocal = sqrVel * Vector3.right * Mathf.Sign (relativeVelocity.x) * antiSlip * -1;

		Vector3 antiSlipVec = transform.TransformDirection (antiSlipVecLocal);

		rigidbody.AddForce (antiSlipVec  * Time.fixedDeltaTime);
	}

	void ApplyThrottle ()
	{
		if (Input.GetKey (KeyCode.W))
			rigidbody.AddForce (transform.forward * Time.fixedDeltaTime * throttle * speed);
		else if (Input.GetKey (KeyCode.S))
			rigidbody.AddForce (transform.forward * Time.fixedDeltaTime * throttle * speed * 1.5f);
		else {
			if(rigidbody.velocity.magnitude > 0.05) {
				rigidbody.AddForce (transform.forward * Time.fixedDeltaTime * speed * -0.9f);
				//Debug.Log(rigidbody.velocity.magnitude);
			}
		}
	}

	void ApplySteering ()
	{
		if(rigidbody.velocity.magnitude > 0)
			transform.RotateAround (transform.position, Vector3.up, steer * Time.fixedDeltaTime * turnSpeed);
	}


	void GetNewDestination ()
	{
		//destination = pathfinder.GetRandomDestination();
		
		Debug.Log (destination);
		Debug.Log (destination.position);
		Debug.Log (destination.localPosition);
	}
	
}
