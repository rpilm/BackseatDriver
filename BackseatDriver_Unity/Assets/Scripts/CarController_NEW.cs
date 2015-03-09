using UnityEngine;
using System.Collections;

public class CarController_NEW : MonoBehaviour {
	
	float throttle=0f;
	public float turnSpeed = 30;
	public float speed = 160; 
	public float antiSlip = 100.0f;
	public GameObject wheels;
	
	void Start () {
		Debug.Log (transform.forward);
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
		rigidbody.AddForce (transform.forward * Time.fixedDeltaTime * throttle * speed );
	}
	
	void ApplySteering ()
	{
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			if(rigidbody.velocity.magnitude > 0)	{
				if (wheels.transform.localRotation.y > -0.3f)	{
					wheels.transform.RotateAround (wheels.transform.position, Vector3.up, -2);
				}
			}
		}
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			if(rigidbody.velocity.magnitude > 0)	{
				if(wheels.transform.localRotation.y < 0.3f) {
					wheels.transform.RotateAround (wheels.transform.position, Vector3.up, 2);
				}
			}
		}
		
		
		transform.RotateAround (transform.position, Vector3.up, wheels.transform.localRotation.y * Time.fixedDeltaTime * turnSpeed);
	}
	
}
