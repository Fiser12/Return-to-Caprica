using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverLaser : MonoBehaviour {
    public float speed;
    private Rigidbody rig;
	public GameObject disparador;

	void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
	// Use this for initialization
	void Start () {
		rig.AddForce(transform.forward*speed, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
