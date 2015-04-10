using UnityEngine;
using System.Collections;

public class TurnWhenFacingWall : MonoBehaviour {

	public float detectionDistance;
	public float chanceToTurnLeft;
	public float chanceToTurnRight;

//	void OnCollisionEnter(Collision collision) {
//		randomlyRotateLeftOrRight();
//	}

	void FixedUpdate() {
//		rigidbody.AddForce( transform.forward * speed, ForceMode.VelocityChange );
		//		Vector3 tempVel = rigidbody.velocity;
		//		tempVel.z = speed;
		//		rigidbody.velocity = tempVel;
		
		// Make a ray
		Ray aRay = new Ray( transform.position, transform.forward );
		RaycastHit aRayHit = new RaycastHit();
		// shoot the shot
		//		RaycastHit info;
		if( Physics.Raycast( aRay, out aRayHit, detectionDistance ) && aRayHit.collider.gameObject.tag == "Wall" ) {
			randomlyRotateLeftOrRight();
		}
		else if( Physics.Raycast( aRay, out aRayHit, 1f ) && aRayHit.collider.gameObject.tag != "Wall" ) {
			randomlyRotateLeftOrRight();
		}
	}

	void bounce() {
		Vector3 vel = GetComponent<Rigidbody>().velocity;
		vel.x = -vel.x;
		vel.y = -vel.y;
		vel.z = -vel.z;
	}

	void randomlyRotateLeftOrRight() {
		float seed = Random.Range( 0f, 1f );
		if( seed < .5f ) {
			transform.Rotate( 0f, -90f, 0f );
		} else {
			transform.Rotate( 0f, 90f, 0f );
		}
	}
}
