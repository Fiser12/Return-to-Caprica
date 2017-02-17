using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {
    public GameObject peligro1;
	public GameObject peligro2;
	public GameObject peligro3;
	public GameObject pegasus;
	public GameObject baseCylon;
    public GameObject nave;
    public Vector3 spawnValues;
	public int numeroAsteroides;
    public float spawnWait;
	private int puntuacion;
	public Text text;
	public Text gameOverText;
	public Text nivelText;
	public Text enemigosText;
	public Text vidaText;

	int enemigosRestantes = 0;
	private bool bolGameOver;
	public int nivel = 0;
	public float period = 1000000f;
	CursorLockMode wantedMode;
	// Use this for initialization
	void Start () {
		gameOverText.gameObject.SetActive (false);
		puntuacion = 0;
        StartCoroutine(SpawnWaves());
		StartCoroutine(CorrutinaNivel());
		nivel = 1;
		wantedMode = CursorLockMode.Locked;
	}
	// Update is called once per frame
	IEnumerator SpawnWaves () {
		Vector3 posicion = transform.position;
		for (int i = 0; i < numeroAsteroides; i++) {
			Vector3 spawnPosition = new Vector3(Random.Range(posicion.x-100f,posicion.x+100f), Random.Range(posicion.y-30f,posicion.y+30f), Random.Range(posicion.z+50,posicion.z+300f));
			float rand = Random.value;
			if (rand < 0.3) {
				Instantiate (peligro1, spawnPosition, Quaternion.identity);
			}else if (rand < 0.6){
				Instantiate (peligro2, spawnPosition, Quaternion.identity);
			}else{
				Instantiate (peligro3, spawnPosition, Quaternion.identity);
			}
		}
		yield return new WaitForSeconds(3f);
    }
	void ActualizarPuntuacion(){
		text.text = "Puntuación: " + puntuacion;
	}
	public void AnadirPuntuacion(int valor){
		puntuacion = puntuacion + valor;
		ActualizarPuntuacion();
	}
	public void GameOver(){
		gameOverText.gameObject.SetActive (true);
		bolGameOver = true;
	}
	void FixedUpdate(){
		if (bolGameOver && Input.GetKeyDown (KeyCode.Mouse0)) {
			SceneManager.LoadScene (0);
		}
		int enemigosRest2 = GameObject.FindGameObjectsWithTag ("Enemy").Length;
		if (enemigosRestantes != enemigosRest2) {
			enemigosRestantes = enemigosRest2;
			enemigosText.text = "Enemigos: " + enemigosRestantes;
		}
	}
	public void setVida(int vida){
		vidaText.text = "Vida: " + vida +"%";
		if(vida>60)
			vidaText.color = Color.green;
		else if(vida>30)
			vidaText.color = Color.yellow;
		else
			vidaText.color = Color.red;
		
	}
	IEnumerator CorrutinaNivel(){
		if (nave != null) {
			Vector3 spawnPosition = Vector3.zero;
			spawnPosition = new Vector3 (Random.Range (-150, 150), Random.Range (-20, 20), Random.Range (400, 300));
			Instantiate (baseCylon, spawnPosition, Quaternion.identity);
		}
	
		SubirNivel ();
		while (!bolGameOver) {
			if ((GameObject.FindGameObjectsWithTag ("Enemy").Length) == 0)
				SubirNivel ();
			yield return new WaitForSeconds (10);
		}
	}
	private void SubirNivel(){
		nivel = nivel + 1;
		nivelText.text = "Nivel: " + nivel;
		setVida (100);
		GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().restaurarVida ();
		GameObject.FindGameObjectWithTag ("BigEnemy").GetComponent<CylonShipController> ().SacarEnemigos(nivel+2);
	}

	// Apply requested cursor state
	void SetCursorState ()
	{
		Cursor.lockState = wantedMode;
		// Hide cursor when locking
		Cursor.visible = (CursorLockMode.Locked != wantedMode);
	}

	void OnGUI ()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
			Cursor.lockState = wantedMode = CursorLockMode.None;
		SetCursorState ();
	}

}
