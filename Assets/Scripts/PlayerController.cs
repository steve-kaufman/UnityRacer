using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerSub))]

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float sensitivity;
	[SerializeField]
	private float acceleration;
	[SerializeField]
	private float maxSpeed;
	[SerializeField]
	private float brakeSpeed;

	
	private PlayerSub motor;


	// Use this for initialization
	void Start () {
		motor = GetComponent<PlayerSub>();
		motor.SetMaxSpeed(maxSpeed);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetAxisRaw("Vertical") == 1) motor.Accel(acceleration);
		if(Input.GetAxisRaw("Vertical") == -1) motor.Brake(brakeSpeed);
		motor.Turn(Input.GetAxis("Horizontal") * sensitivity);
	}
	
}
