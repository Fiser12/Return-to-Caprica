using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearWithDistance : MonoBehaviour {
	public Transform player;
	public float distanceMinimum;

	void Start () {
		float distance = Vector3.Distance (transform.position, player.position);

		if(distance>distanceMinimum)
			Destroy(gameObject);
	}

	// Use this for initialization
}
