using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	//Groups
	public GameObject[] groups;



	void Start()
	{
		// Initial spawn group
		spawnNext ();
	}

	public void spawnNext ()
	{
		//Spawn Group at the current Position

		GameObject go=
		Instantiate (groups[FindObjectOfType<Queue>().next()],
			transform.position,
				Quaternion.identity) as GameObject;
		//set the groups' parent
		go.transform.parent = this.transform;

		//playe generator effect
		GetComponent<AudioSource>().Play();
	}

}
