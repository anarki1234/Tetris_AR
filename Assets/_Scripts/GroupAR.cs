using UnityEngine;
using System.Collections;

public class GroupAR : Group {

	public float movingFreezingTime=0.5f;

	private float movingTime=0f;

	// Time since last gravity tick
	private float lastFall = 0;



	// Update is called once per frame
	void Update () {
		// Move Right
		if (VBInputEvent.instance.whichButton==2 ) { //virtual button right input


			movingTime += Time.deltaTime;


			if (movingTime > movingFreezingTime) {
				// Modify position
				transform.position += new Vector3 (1, 0, 0);

				// See if valid
				if (isValidGridPos ())
					// It's valid. Update grid.
					updateGrid ();
				else
					// It's not valid. revert.
					transform.position += new Vector3 (-1, 0, 0);
				movingTime = 0f;
			}
		}



		// Move Left
		if ( VBInputEvent.instance.whichButton==1) { //virtual button left input
			// Modify position

			movingTime += Time.deltaTime;


			if (movingTime > movingFreezingTime) {
				transform.position += new Vector3 (-1, 0, 0);

				// See if valid
				if (isValidGridPos ())
					// Its valid. Update grid.
					updateGrid ();
				else
					// Its not valid. revert.
					transform.position += new Vector3 (1, 0, 0);
				movingTime = 0f;
			}
		}

		// Rotate
		if (VBInputEvent.instance.whichButton==3) { //virtualbutton rotation input
			transform.Rotate(0, 0, -90);

			// See if valid
			if (isValidGridPos())
				// It's valid. Update grid.
				updateGrid();
			else
				// It's not valid. revert.
				transform.Rotate(0, 0, 90);
		}

		//fall
		if (Time.time - lastFall >= FindObjectOfType<Queue>().TimeFrame) {
			// Modify position
			transform.position += new Vector3(0, -1, 0);

			// See if valid
			if (isValidGridPos()) {
				// It's valid. Update grid.
				updateGrid();
			} else {
				// It's not valid. revert.
				transform.position += new Vector3(0, 1, 0);

				// Clear filled horizontal lines
				Grid.deleteFullRows();

				// Spawn next Group
				FindObjectOfType<Spawner>().spawnNext();

				// Disable script
				enabled = false;
			}

			lastFall = Time.time;
		}
	}



}
