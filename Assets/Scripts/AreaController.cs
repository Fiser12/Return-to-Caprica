using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour
{
	public GameObject planeta;
	private GameObject jugador;
	public GameObject explosionAsteroide;
	public GameObject playerExplosion;
	private GameController gameController;


	void Start(){
		jugador = GameObject.FindGameObjectWithTag ("Player");
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
		if (jugador != null) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, jugador.transform.position.z);
			planeta.transform.position = new Vector3 (planeta.transform.position.x, planeta.transform.position.y, jugador.transform.position.z + 1000f);
		}
	}

}
