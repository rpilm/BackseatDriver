using UnityEngine;
using System.Collections;

public class CarController_NEW : MonoBehaviour {
	float translation;
	float rotation;
	public float acceleration;
	public Rigidbody rb;
	float turn;
	//******NOTE*********
	//"speed" variable is not used in movement, just used for rotationSpeed calculation
	public float speed;
	public float rotationSpeed = 5.0F;

	void Start()	{
		rb = GetComponent<Rigidbody> ();
		acceleration = 0;
		speed = 0;
	}

	// Update is called once per frame
	void Update () {
		//W key essentially is treated as gas pedal
		if (Input.GetKey (KeyCode.W))
			acceleration = 1.25f;
		//S key is the brakes
		else if (Input.GetKey (KeyCode.S))
			acceleration = -1.5f;
		else
			acceleration = -0.65f;

		if (Input.GetKey (KeyCode.A) == false && Input.GetKey (KeyCode.D) == false)
			rigidbody.angularDrag = 5.5f;
		else
			rigidbody.angularDrag = 3.5f;

		turn = Input.GetAxis ("Horizontal");


		speed += acceleration/2;

		//Maximum and minimum "speeds"
		if (speed < 0)
			speed = 0;
		if (speed > 100)
			speed = 100;

		if (rigidbody.velocity.magnitude < 0.01 && Input.GetKey(KeyCode.W) == false) {
			acceleration = 0;
			rigidbody.velocity = Vector3.zero;
		}
		
		rb.AddForce (transform.forward * acceleration, ForceMode.Acceleration);
		rb.AddTorque (transform.up * rotationSpeed * turn);
	}
}
