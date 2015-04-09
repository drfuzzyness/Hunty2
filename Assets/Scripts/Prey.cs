using UnityEngine;
using System.Collections;

//[RequireComponent (typeof (Mob))]
public class Prey : MonoBehaviour {
	public bool canMove;
	public float fleeRandomAngle;
	private bool fleeing;

	public void flee() {
		// run in circles!
		if( canMove ) {
			GetComponent<Mob>().run();
			transform.Rotate( transform.right * Random.Range( -fleeRandomAngle, fleeRandomAngle ) );
		}
		fleeing = true;
	}

	public void flee( Hunter theHunter ) {
		// run from the baddie!
		if( canMove ) {
			GetComponent<Mob>().run();
			GetComponent<Mob>().turnToFace( theHunter.transform );
			Vector3 tempRotation = transform.eulerAngles;
			if( tempRotation.y >= 0f ) {
				tempRotation.y += 180f;
			} else {
				tempRotation.y -= 180f;
			}
			transform.eulerAngles = tempRotation;
		}
		fleeing = true;
	}

	public void calm() {
		if( fleeing ) {
			GetComponent<Mob>().walk();
			fleeing = false;
		}
	}

	public bool isFleeing() {
		return fleeing;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
