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
    public int numeroEnemigos;
    public float spawnWait;
	private int puntuacion;
	public Text text;
	public Text gameOverText;
	public Text nivelText;

	private bool bolGameOver;
	private int nivel;
	public float period = 1000000f;
	// Use this for initialization
	void Start () {
		gameOverText.gameObject.SetActive (false);
		puntuacion = 0;
        StartCoroutine(SpawnWaves());
		StartCoroutine(CorrutinaNivel());
		nivel = 1;
	}
	
	// Update is called once per frame
	IEnumerator SpawnWaves () {
        yield return new WaitForSeconds(3f);
		while (!bolGameOver)
        {
            for (int i = 0; i < numeroEnemigos; i++)
            {
				Vector3 spawnPosition = Vector3.zero;
				if (nave != null)
					spawnPosition = new Vector3(Random.Range(nave.transform.position.x-6,nave.transform.position.x+6), Random.Range(nave.transform.position.y-6,nave.transform.position.y+6), Random.Range(nave.transform.position.z+30,nave.transform.position.z+40));
				float rand = Random.value;
				if (rand < 0.3) {
					Instantiate (peligro1, spawnPosition, Quaternion.identity);
				}else if (rand < 0.6){
					Instantiate (peligro2, spawnPosition, Quaternion.identity);
				}else{
					Instantiate (peligro3, spawnPosition, Quaternion.identity);
				}

				yield return new WaitForSeconds(spawnWait);
            }
			yield return new WaitForSeconds(spawnWait);
        }
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
		} else {
		}
	}
	IEnumerator CorrutinaNivel(){
		while (!bolGameOver) {
			yield return new WaitForSeconds (10);
			SubirNivel ();
		}
	}
	private void SubirNivel(){
		nivel = nivel + 1;
		numeroEnemigos = numeroEnemigos + 2;
		nivelText.text = "Nivel: " + nivel;
		Vector3 spawnPosition = Vector3.zero;
		if (nivel % 2 != 0) {
			if (nave != null) {
				spawnPosition = new Vector3 (-200, Random.Range (0, 50), Random.Range (nave.transform.position.z + 300, nave.transform.position.z + 400));
				Instantiate (pegasus, spawnPosition, Quaternion.identity);
			}
		} else {
			if (nave != null) {
				spawnPosition = new Vector3 (200, Random.Range (0, 50), Random.Range (nave.transform.position.z + 300, nave.transform.position.z + 400));
				Instantiate (baseCylon, spawnPosition, Quaternion.identity);
			}
		}
	}
}
