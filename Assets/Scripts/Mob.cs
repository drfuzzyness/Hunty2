using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class Mob : MonoBehaviour {


	public float walkSpeed;
	public float runSpeed;
	public bool startWalking;
	private float currentSpeed;
	public bool isWalking;
	public bool isRunning;

	public void turnToFace( Transform target ) {
		transform.LookAt( target );
	}

	public void walk() {
		isWalking = true;
		isRunning = false;
		GetComponent<Rigidbody>().drag = .01f;
		currentSpeed = walkSpeed;

	}

	public void run() {
		isWalking = false;
		isRunning = true;
		GetComponent<Rigidbody>().drag = .01f;
		currentSpeed = runSpeed;
	}

	public void stop() {
		isWalking = false;
		isRunning = false;
		currentSpeed = 0f;
		GetComponent<Rigidbody>().drag = 1000f;
	}

	void Start() {
		stop();
		if( startWalking ) {
			walk();
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		// move forward if walking or running and is moving slower than maxspeed
		if( ( isWalking || isRunning ) && GetComponent<Rigidbody>().velocity.magnitude < currentSpeed ) {
			GetComponent<Rigidbody>().AddForce( transform.forward * currentSpeed / 4, ForceMode.VelocityChange );
		}
	}
}
