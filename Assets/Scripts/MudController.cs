using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudController : MonoBehaviour {

	public float velocity = 350;

	// Use this for initialization
	void Start ()
	{
		transform.localScale = new Vector3(Random.Range(4, 10), 0.5f, 7);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponentInParent<Rigidbody>().MovePosition(transform.position + transform.right * velocity * Time.deltaTime);
	}
}
