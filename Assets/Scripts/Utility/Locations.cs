/*Purpose: A debugging tool to show position of the parent object in the gameSpace.
 * 
 * Special Notes: N/A
 * 
 * Author: Devyn Cyphers */

using UnityEngine;
using System.Collections;

public class Locations : MonoBehaviour {

    // variables to be used.
    public Vector3 localPosition;
    public Vector3 position;

	// Init.
	void Start () {
        updatePositions();
	}
	
	// Update.
	void Update () {

        if (localPosition != transform.localPosition||position != transform.position) { updatePositions(); }

	}

    // Updates the position variables.
    void updatePositions() {

        localPosition = transform.localPosition;
        position = transform.position;

    }
}
