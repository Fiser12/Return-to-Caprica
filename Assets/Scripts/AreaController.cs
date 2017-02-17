using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour
{
	public GameObject explosionAsteroide;
	public GameObject playerExplosion;
	private GameController gameController;


	void Start(){
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}
    private void OnTriggerExit(Collider other)
    {
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		} else {
			Instantiate(explosionAsteroide, transform.position, transform.rotation);
		}

        Destroy(other.gameObject);
    }
	void Update(){
	}

}
