using UnityEngine;
using System.Collections;

public class CarController_NEW : MonoBehaviour {
	float translation;
	float rotation;
	float acceleration;

	public float speed = 0F;
	public float rotationSpeed = 100.0F;

	void Start()	{
		acceleration = 0;
	}

	// Update is called once per frame
	void Update () {
		//W key essentially is treated as gas pedal
		if (Input.GetKey (KeyCode.W))
			acceleration = 0.0005f;
		else if (Input.GetKey (KeyCode.S))
			acceleration = -0.001f;
		else
			acceleration = -0.0005f;

		speed += acceleration;

		//Maximum and minimum speeds
		if (speed < 0)
			speed = 0;
		if (speed > 0.3f)
			speed = 0.3f;

		rotationSpeed = speed * 1000f;
		if (rotationSpeed > 100f)
			rotationSpeed = 100;

		translation = Input.GetAxis("Vertical") * speed;
		rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate(0, 0, speed);
		transform.Rotate(0, rotation, 0);
	}
}
