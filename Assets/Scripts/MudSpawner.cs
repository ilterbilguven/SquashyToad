using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudSpawner : MonoBehaviour
{
	public float nextSpawnTime = 0;

	public GameObject mudPrefab;

	public int direction;

	public int velocity;

	public float meanTime = 2;

	void Start()
	{
		direction = Random.Range(0, 2);
		velocity = direction == 0 ? Random.Range(350, 1000) : Random.Range(-350, -1000);
	}

	void FixedUpdate () {
		if (Time.time > nextSpawnTime)
		{
			var mud = Instantiate(mudPrefab);
			mud.transform.parent = transform;
			mud.transform.localPosition = direction == 0 ? new Vector3(-55, 0.125f, 0) : new Vector3(55, 0.125f, 0);
			mud.transform.localScale = new Vector3(1,1,1);
			mud.GetComponentInChildren<MudController>().velocity = velocity;

			nextSpawnTime = Time.time + 3 - Mathf.Log(Random.value) * meanTime;
		}	
	}
}
