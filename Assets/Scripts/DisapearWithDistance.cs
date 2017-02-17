using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearWithDistance : MonoBehaviour {
	public GameObject player;
	public float distanceMinimum;

	void Start () {
		player = GameObject.FindWithTag ("Player");
	}
	void FixedUpdate(){
		if (player != null) {
			float distance = Vector3.Distance (transform.position, player.transform.position);
			if (distance > distanceMinimum)
				Destroy (gameObject);
		}
	}
	// Use this for initialization
}
