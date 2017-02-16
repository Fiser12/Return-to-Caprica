using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylonShipController : MonoBehaviour {	
	private float nextFire;
	public float fireRate;
	public GameObject shot;
	public Transform shotSpawn1;
	public Transform shotSpawn2;
	public Transform shotSpawn3;
	public Transform shotSpawn4;
	public GameObject target;
	private Rigidbody rig;
	private AudioSource audioDisparo;

	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody> ();
		audioDisparo = (AudioSource)GetComponents<AudioSource> ().GetValue (1);
		Vector3 euler = transform.eulerAngles;
		euler.y = Random.Range(0f, 360f);
		transform.eulerAngles = euler;
	}
	void Update(){
		GetComponent<Transform>().LookAt (target.GetComponent<Transform> ());
	}
	void FixedUpdate () {
		if (Time.time>nextFire)
		{

			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn1.position, transform.rotation);
			Instantiate(shot, shotSpawn2.position, transform.rotation);
			Instantiate(shot, shotSpawn3.position, transform.rotation);
			Instantiate(shot, shotSpawn4.position, transform.rotation);
			audioDisparo.Play ();
		}

	}
}
