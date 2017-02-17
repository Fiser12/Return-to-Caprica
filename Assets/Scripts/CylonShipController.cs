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
	private Rigidbody rig;
	private AudioSource audioDisparo;
	private GameController gameController;
	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		target = GameObject.FindWithTag ("Player");
		rig = GetComponent<Rigidbody> ();
		audioDisparo = (AudioSource)GetComponents<AudioSource> ().GetValue (1);
		Vector3 euler = transform.eulerAngles;
		euler.y = Random.Range(0f, 360f);
		transform.eulerAngles = euler;
		for (int i = 0; i < gameController.nivel+3; i++) {
			var randomPos = Random.insideUnitSphere * 20;
			Instantiate(cylonRaider, transform.position + randomPos, Quaternion.identity);
		}

	}
	void Update(){
	
	}
	void FixedUpdate () {

	}
}
