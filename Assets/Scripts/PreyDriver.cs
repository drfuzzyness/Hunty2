using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Prey))]
public class PreyDriver : MonoBehaviour {
	public ParticipantManager manager;

	public void caught() {
		manager.prey.Remove( this.GetComponent<Prey>() );
		Destroy( this.gameObject );
	}

	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		// turn when at wall
	}
}
