using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylonRaiderController : MonoBehaviour {
    private Rigidbody rig;
    public float speed;
	public Transform target;
	private float nextFire;
	public float fireRate;
	private bool descansoArma;
	private int disparos = 0;
	private int disparosPorRafaga = 5;
	private float descansoRate = 2;
	private float nextRafaga;

	private AudioSource audioDisparo;
	public GameObject shot;
	public Transform shotSpawn1;
	public Transform shotSpawn2;
	void Start(){
		target = GameObject.FindWithTag ("Player").transform;
	}
	// Use this for initialization
	void Awake () {
        rig = GetComponent<Rigidbody>();
		audioDisparo = GetComponent<AudioSource>();
		descansoArma = false;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (disparosPorRafaga < disparos) {
			descansoArma = true;
			nextRafaga = Time.time + descansoRate;
			disparos = 0;
		}
		if (descansoArma&&Time.time>nextRafaga) {
			descansoArma = false;
		}
		if (target != null) {
			float distance = Vector3.Distance (transform.position, target.position);
			if (distance < 5) {
				transform.LookAt (target);
			} else if (distance < 20) {
				transform.LookAt (target);
				if (Time.time > nextFire) {
					rig.AddRelativeForce (Vector3.forward * speed / 3);
					if (!descansoArma) {
						disparos++;
						nextFire = Time.time + fireRate;
						Instantiate (shot, shotSpawn1.position, transform.rotation);
						Instantiate (shot, shotSpawn2.position, transform.rotation);
						audioDisparo.Play ();
					}
				}
			} else if (distance < 400) {
				transform.LookAt (target);
				rig.AddRelativeForce (Vector3.forward * speed);
			} 
		} else {
			transform.LookAt (target);
		}
		rig.velocity = rig.velocity * 0.986f;
	}
}
