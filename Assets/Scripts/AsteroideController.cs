using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroideController : MonoBehaviour {
    private Rigidbody rig;
    public float tumble;
	// Use this for initialization
	void Awake () {
        rig = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Start () {
        rig.angularVelocity = Random.insideUnitSphere*tumble;
		rig.velocity = Random.insideUnitSphere*tumble;
	}
}
