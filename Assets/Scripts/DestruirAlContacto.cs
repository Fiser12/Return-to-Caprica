using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirAlContacto : MonoBehaviour {
    public GameObject explosionAsteroide;
    public GameObject playerExplosion;
	private GameController gameController;
	void Start(){
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary") return;

		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		} else {
			gameController.AnadirPuntuacion (100);
			Instantiate(explosionAsteroide, transform.position, transform.rotation);
		}
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
