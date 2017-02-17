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
			Vector3 avanzar = Vector3.forward;
			float distance = Vector3.Distance (transform.position, target.position);
			if (distance < 5) {
				RotateTowardsPlayer ();
			} else if (IsPlayerWithinAttackRange()) {
				RotateTowardsPlayer ();
				if (Time.time > nextFire) {
					MoveForward();
					Fire ();
				}
			} else if (IsPlayerWithinApproachRange()) {
				transform.LookAt (target);
				MoveForward();
			} 
		} else {
			transform.LookAt (target);
		}
		rig.velocity = rig.velocity * 0.986f;
	}
	void RotateTowardsPlayer()
	{
		rig.AddRelativeForce (Random.insideUnitSphere * speed * 5); //Para evitar que convergan todos en el mismo sitio
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), (speed/2) * Time.deltaTime);
	}
	void MoveForward()
	{
		transform.position += transform.forward * speed * Time.deltaTime;
	}
	bool IsPlayerWithinApproachRange()
	{
		var distance = (target.position - transform.position).magnitude;
		return distance < 400;
	}
	bool IsPlayerWithinAttackRange()
	{
		var distance = (target.position - transform.position).magnitude;
		return distance < 20;
	}

	void Fire()
	{
		if (!descansoArma) {
			disparos++;
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn1.position, transform.rotation);
			Instantiate (shot, shotSpawn2.position, transform.rotation);
			audioDisparo.Play ();
		}
	}

}
