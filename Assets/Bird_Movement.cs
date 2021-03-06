﻿using UnityEngine;
using System.Collections;

public class Bird_Movement : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
	public Vector3 gravity;
	public Vector3 flapVelocity;
	public float maxSpeed = 5f;
	public float forwardSpeed = 1f;

	bool didFlap = false;

	// Use this for initialization
	void Start () {
	
	}
	//Do Graphics and Input
	void Update(){
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			didFlap = true;
		}
	}
	
	// Do Physics and Engine update
	void FixedUpdate () {
		velocity.x = forwardSpeed;
		velocity += gravity * Time.deltaTime;

		if (didFlap == true) {
			didFlap = false;
			if (velocity.y < 0)
				velocity.y = 0;

			velocity += flapVelocity;
		}

		velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

		transform.position += velocity * Time.deltaTime;

		float angle = 0;
		if (velocity.y < 0) {
			angle = Mathf.Lerp (0, -90, -velocity.y / maxSpeed);
		}
		transform.rotation = Quaternion.Euler (0, 0, angle);
	}
}