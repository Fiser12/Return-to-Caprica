using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public float damping = 0.70f;
	Vector3 offset;
	void Start () {
		Vector3 temp = player.transform.position;
		temp.y = player.gameObject.transform.position.y + 2;
		temp.x = player.gameObject.transform.position.x;
		temp.z = player.gameObject.transform.position.z - 5;
		transform.position = temp;
		Vector3 rot = player.gameObject.transform.rotation.eulerAngles;
		rot = new Vector3(rot.x+20,rot.y,rot.z);
		offset = player.transform.position - transform.position;

	}
	void LateUpdate() {
		if (player != null) {
			float currentAngleY = transform.eulerAngles.y;
			float desiredAngleY = player.transform.eulerAngles.y;
			float angleY = Mathf.LerpAngle(currentAngleY, desiredAngleY, Time.deltaTime * damping);

			Quaternion rotation = Quaternion.Euler(0, angleY, 0);
			transform.position = player.transform.position - (rotation * offset);

			transform.LookAt(player.transform);

		}
	}
}
