using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{

	public GameObject treePrefab;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < Random.Range(1,4); i++)
		{
			var tree = Instantiate(treePrefab);
			tree.transform.parent = transform;
			tree.transform.localPosition = new Vector3(Random.Range(-49, 50), 0.5f, Random.Range(-4, 5));
		}
	}
}
