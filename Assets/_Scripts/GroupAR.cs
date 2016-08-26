using UnityEngine;
using System.Collections;

public class GroupAR : Group {

	public float movingFreezingTime=0.5f;

	private float pressingButtonTime=0f;





	// Update is called once per frame
	void Update () {
		// Move Right
		if (VBInputEvent.instance.whichButton==2 ) { //virtual button right input


			pressingButtonTime += Time.deltaTime;


			if (pressingButtonTime > movingFreezingTime) {
				// Modify position
				transform.position += new Vector3 (1, 0, 0);

				// See if valid
				if (isValidGridPos ())
					// It's valid. Update grid.
					updateGrid ();
				else
					// It's not valid. revert.
					transform.position += new Vector3 (-1, 0, 0);
				pressingButtonTime = 0f;
			}
		}



		// Move Left
		if ( VBInputEvent.instance.whichButton==1) { //virtual button left input
			// Modify position

			pressingButtonTime += Time.deltaTime;


			if (pressingButtonTime > movingFreezingTime) {
				transform.position += new Vector3 (-1, 0, 0);

				// See if valid
				if (isValidGridPos ())
					// Its valid. Update grid.
					updateGrid ();
				else
					// Its not valid. revert.
					transform.position += new Vector3 (1, 0, 0);
				pressingButtonTime = 0f;
			}
		}

		// Rotate
		if (VBInputEvent.instance.whichButton==3) { //virtualbutton rotation input
			pressingButtonTime += Time.deltaTime;
			if (pressingButtonTime > movingFreezingTime) {
				transform.Rotate (0, 0, -90);

				// See if valid
				if (isValidGridPos ())
				// It's valid. Update grid.
				updateGrid ();
				else
				// It's not valid. revert.
				transform.Rotate (0, 0, 90);
				pressingButtonTime = 0f;
			}
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
