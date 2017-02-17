using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylonShipController : MonoBehaviour {	
	public GameObject cylonRaider;
	public Transform Spawn1;
	public Transform Spawn2;
	public Transform Spawn3;
	public Transform Spawn4;
	public GameObject target;
	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag ("Player");
		Vector3 euler = transform.eulerAngles;
		euler.y = Random.Range(0f, 360f);
		transform.eulerAngles = euler;
	}
	public void SacarEnemigos(int enemigos){
		for (int i = 0; i < enemigos; i++) {
			var randomPos = Random.insideUnitSphere * 50;
			Instantiate(cylonRaider, transform.position + randomPos, Quaternion.identity);
		}
	}
	void Update(){
	
	}
	void FixedUpdate () {

	}
}
