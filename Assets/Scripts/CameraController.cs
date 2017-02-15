using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
		if (player != null) {
			Vector3 temp = player.transform.position;
			temp.y = player.gameObject.transform.position.y + 2;
			temp.x = player.gameObject.transform.position.x;
			temp.z = player.gameObject.transform.position.z - 5;
			transform.position = temp;
			Vector3 rot = player.gameObject.transform.rotation.eulerAngles;
			rot = new Vector3(rot.x+20,rot.y,rot.z);
			transform.rotation = Quaternion.FromToRotation (temp, player.gameObject.transform.position);
		}
	}
}
