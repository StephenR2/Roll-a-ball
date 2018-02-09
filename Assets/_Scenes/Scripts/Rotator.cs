/* Stephen Randall
 * 02/08/18
 * This file allows the pickups to rotate in place.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime); // Rotates the pickup by a specified Vector3.
	}
}
