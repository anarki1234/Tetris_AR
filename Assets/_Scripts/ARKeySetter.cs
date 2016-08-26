using UnityEngine;
using System.Collections;
using Vuforia;
using System.IO;
public class ARKeySetter : MonoBehaviour {

	// Use this for initialization
	void Awake(){

		#if UNITY_EDITOR

		Debug.Log("start to read and set key");

		string apiKey = ReadKey();
		GetComponent<VuforiaBehaviour> ().SetAppLicenseKey (apiKey);

		#endif
	}


	string ReadKey(){
		string keyLocation="Builds/apiKey.txt";

		if (File.Exists (keyLocation)) {

			Debug.Log ("there is a file");


			return File.ReadAllText (keyLocation);

		} else {


			Debug.LogError("Apply key on developer.vuforia.com, " +
				"and creat a apiKey.txt in Builds folder, and paste it to the txt file");


		}

		return null;

	}

}
