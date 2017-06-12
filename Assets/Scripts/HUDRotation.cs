using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDRotation : MonoBehaviour {

	// Update is called once per frame
	void Update ()
	{
		transform.rotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.parent.GetComponentInChildren<Camera>().transform.forward, Vector3.up).normalized);
	}
}
