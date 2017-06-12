using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{

	public float velocity;

	void FixedUpdate ()
	{
		GetComponentInChildren<Rigidbody>().MovePosition(transform.GetChild(0).position + transform.GetChild(0).right * velocity * Time.deltaTime);
	}
}
