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
	public GameObject caprica;
    public GameObject nave;

    public Vector3 spawnValues;
	public int numeroAsteroides;
    public float spawnWait;
	private int puntuacion;
	public Text text;
	public Text gameOverText;
	public Text nivelText;

	private bool bolGameOver;
	public int nivel = 0;
	public float period = 1000000f;
	CursorLockMode wantedMode;
	// Use this for initialization
	void Start () {
		gameOverText.gameObject.SetActive (false);
		puntuacion = 0;
        //StartCoroutine(SpawnWaves());
		StartCoroutine(CorrutinaNivel());
		nivel = 1;
		wantedMode = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	IEnumerator SpawnWaves () {
        yield return new WaitForSeconds(3f);
		while (!bolGameOver)
        {
            for (int i = 0; i < numeroAsteroides; i++)
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
		SubirNivel ();
		while (!bolGameOver) {
			if ((GameObject.FindGameObjectsWithTag ("Enemy").Length + GameObject.FindGameObjectsWithTag ("BigEnemy").Length) == 0)
				SubirNivel ();
			yield return new WaitForSeconds (10);
		}
	}
	private void SubirNivel(){
		nivel = nivel + 1;
		nivelText.text = "Nivel: " + nivel;
		Vector3 spawnPosition = Vector3.zero;
		if (nave != null) {
			spawnPosition = new Vector3 (Random.Range (-150, 150), Random.Range (0, 20), Random.Range (500, 300));
			Instantiate (baseCylon, spawnPosition, Quaternion.identity);
		}
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
