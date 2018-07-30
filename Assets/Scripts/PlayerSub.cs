using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerSub : MonoBehaviour {

	private float maxSpeed = 0f;


	private Rigidbody rb;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	public void Accel(float acceleration){
		Vector3 localVelocity = transform.rotation * rb.velocity;
		if(localVelocity.z >= maxSpeed) return;
		print(localVelocity.z);
		Vector3 force = rb.rotation * new Vector3(0f, 0f, -acceleration / 10);
		//force = force.normalized * Time.deltaTime;
		rb.velocity += force;
	}

	public void Brake(float brakeSpeed){
		Vector3 localVelocity = transform.rotation * rb.velocity;
		if(localVelocity.z <= 0) return;
		Vector3 brakeVector = rb.rotation * new Vector3(0f, 0f, -brakeSpeed / 10);
		rb.velocity -= brakeVector;
	}

	public void SetMaxSpeed(float _maxSpeed){
		maxSpeed = _maxSpeed;
	}

	public void Turn(float turnFactor){
		Vector3 _turn = new Vector3(0f, turnFactor / 10, 0f);
		rb.MoveRotation(rb.rotation * Quaternion.Euler(_turn));
	}

}
