using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverLaser : MonoBehaviour {
    public float speed;
    private Rigidbody rig;
	public GameObject disparador;
	private GameController gameController;
	private PlayerController playerController;

	public GameObject explosionEnemigo;
	public GameObject playerExplosion;

	void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		playerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();

		rig.AddForce(transform.forward*speed, ForceMode.Impulse);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary") return;

		if (other.tag == "Player" && disparador.tag!="Player") {
			playerController.dañoRecibido (20);
			gameController.setVida (playerController.vida);
			if (playerController.vida == 0) {
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				gameController.GameOver ();
				Destroy (other.gameObject);
				Destroy (gameObject);
			}
		} else if (other.tag == "Enemy" && disparador.tag!="Enemy"){
			gameController.AnadirPuntuacion (300);
			Instantiate(explosionEnemigo, transform.position, transform.rotation);
			Destroy(other.gameObject);
			Destroy(gameObject);
		}else if (other.tag == "Asteroid"){
			gameController.AnadirPuntuacion (100);
			Instantiate(explosionEnemigo, transform.position, transform.rotation);
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
	}
}
