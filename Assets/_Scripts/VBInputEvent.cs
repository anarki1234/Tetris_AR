using UnityEngine;
using System.Collections.Generic;
using Vuforia;


/// <summary>
/// This class implements the IVirtualButtonEventHandler interface and
/// contains the logic to swap materials for the teapot model depending on what 
/// virtual button has been pressed.
/// </summary>
public class VBInputEvent : MonoBehaviour,
                                         IVirtualButtonEventHandler
{
	public static VBInputEvent instance=null;


	/// <summary>
	/// The which button.
	/// 0: no button
	/// 1: left
	/// 2 right
	/// 3: rotation
	/// </summary>
	[HideInInspector]
	public int whichButton=0;

	void Awake(){

		if(instance!=null){
			Destroy(this.gameObject);
		}else{
			instance=this;
		}

	}


    #region MONOBEHAVIOUR_METHODS
    void Start()
    {
        // Register with the virtual buttons TrackableBehaviour
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            vbs[i].RegisterEventHandler(this);
        }


    }

    #endregion // MONOBEHAVIOUR_METHODS


    #region PUBLIC_METHODS
    /// <summary>
    /// Called when the virtual button has just been pressed:
    /// </summary>
    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
        Debug.Log("OnButtonPressed: " + vb.VirtualButtonName);



        // Add the material corresponding to this virtual button
        // to the active material list:
        switch (vb.VirtualButtonName)
        {
		case "Left":
			Debug.Log ("press left button");
			whichButton = 1;
                break;

		case "Right":
			Debug.Log ("press right button");
			whichButton = 2;
                break;

		case "Rotation":
			Debug.Log ("press rotation button");
			whichButton = 3;
                break;




        }

    }

    /// <summary>
    /// Called when the virtual button has just been released:
    /// </summary>
    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {


        // Remove the material corresponding to this virtual button
        // from the active material list:
        switch (vb.VirtualButtonName)
        {
		case "Left":
			Debug.Log ("release left button");
			whichButton = 0;
			break;

		case "Right":
			Debug.Log ("release right button");
			whichButton = 0;
			break;

		case "Rotation":
			Debug.Log ("release rotation button");
			whichButton = 0;
			break;
        }


    }
    #endregion //PUBLIC_METHODS


}
