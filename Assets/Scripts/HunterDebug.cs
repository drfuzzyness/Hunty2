using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Hunter))]
public class HunterDebug : MonoBehaviour {

	void OnDrawGizmos() {
		if( GetComponent<Hunter>().chasing ) {
			Vector3 vectorToPrey = GetComponent<Hunter>().getPrey().transform.position - transform.position;
			Gizmos.DrawRay( transform.position, vectorToPrey);
		}
	}
}
