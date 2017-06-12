using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum LaneType
{
	Safe,
	Danger
};
public class LaneSpawner : MonoBehaviour
{
	public GameObject[] safeLanePrefabs;
	public GameObject[]	dangerousLanePrefabs;

	public int laneSpawnDistance = 10000;
	private LaneType lastLaneType = LaneType.Safe;
	private float safeRunProbability = 0.2f;
	int offset = 0;

	public GameObject player;

	// Use this for initialization
	void Update ()
	{
		while (offset < laneSpawnDistance + player.transform.position.z)
		{
			CreateRandomLane(offset+=1000);
		}
		foreach (Transform lane in transform)
		{
			if (lane.transform.position.z + laneSpawnDistance < player.transform.position.z)
			{
				Destroy(lane.gameObject);
			}
		}

	}

	void CreateRandomLane(float offset)
	{

		var lane = InstantiateRandomLane(lastLaneType == LaneType.Safe ? dangerousLanePrefabs : safeLanePrefabs);
		lastLaneType = (lastLaneType == LaneType.Safe || Random.value < safeRunProbability) ? LaneType.Danger : LaneType.Safe;

		lane.transform.parent = transform;
		lane.transform.position = new Vector3(0, 0, offset);
	}

	GameObject InstantiateRandomLane(GameObject[] lanes)
	{
		return Instantiate(lanes[Random.Range(0, lanes.Length)]);
	}
}
