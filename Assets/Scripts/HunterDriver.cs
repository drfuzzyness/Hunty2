using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Hunter))]
public class HunterDriver : MonoBehaviour {
	public ParticipantManager manager;



	// Update is called once per frame
	void Update () {
		if( !GetComponent<Hunter>().chasing ) {
			foreach( Prey thisPrey in manager.prey ) {
				if( GetComponent<Hunter>().sees( thisPrey.gameObject ) && !GetComponent<Hunter>().chasing ) {
					GetComponent<Hunter>().chase( thisPrey.gameObject );
					thisPrey.flee( GetComponent<Hunter>() );
				}
			}
		}
	}
}
