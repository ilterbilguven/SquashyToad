using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour {

	public GameObject carPrefab;
	public GameObject truckPrefab;

	public int[] velocity;
	public float[] nextSpawnTime;

	public float[] meanTime;

	void Start()
	{
		velocity = new int[2];
		nextSpawnTime = new float[2];

		velocity[0] = Random.Range(350, 1000);
		velocity[1] = Random.Range(-350, -1000);

		nextSpawnTime[0] = 0;
		nextSpawnTime[1] = 0;
	}

	void FixedUpdate () {
		if (Time.time > nextSpawnTime[0])
		{
			var vehicle = Instantiate(FlipCoin() == 0 ? carPrefab : truckPrefab);
			vehicle.transform.parent = transform;
			vehicle.transform.localScale = new Vector3(-1, 1, 1);
			vehicle.transform.localPosition = new Vector3(0, 0, 0);
			vehicle.GetComponent<VehicleController>().velocity = velocity[0];

			nextSpawnTime[0] = Time.time + 3 - Mathf.Log(Random.value) * meanTime[0];
		}

		if (Time.time > nextSpawnTime[1])
		{
			var vehicle = Instantiate(FlipCoin() == 0 ? carPrefab : truckPrefab);
			vehicle.transform.parent = transform;
			vehicle.transform.localPosition = new Vector3(0, 0, 5f);
			vehicle.transform.localScale = new Vector3(1, 1, 1);
			vehicle.GetComponent<VehicleController>().velocity = velocity[1];

			nextSpawnTime[1] = Time.time + 3 - Mathf.Log(Random.value) * meanTime[1];
		}
	}

	int FlipCoin()
	{
		return Random.Range(0, 2);
	}
}
