using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rigidBody;
    public GameObject shot;
    public Transform shotSpawn1;
	public Transform shotSpawn2;

    public int speed = 10;
    public int till;
	public float nextFire;
	public float fireRate;
	private float xPoint;
	private float yPoint;
	private AudioSource audioDisparo;

	int mouseSensativity = 15;
	bool invertPitch = true;
	void Start(){

	}
    private void Awake()
    {
		rigidBody = GetComponent<Rigidbody>();
		audioDisparo = GetComponent<AudioSource>();

    }
    private void FixedUpdate()
    {
		int invertPitchInt; 
		if (invertPitch) {
			invertPitchInt = -1;
		}
		else invertPitchInt = 1;
		if (Input.GetKey("w")) { rigidBody.AddRelativeForce (Vector3.forward * speed); } 
		if (Input.GetKey("s")) { rigidBody.AddRelativeForce (Vector3.forward * -1 * speed); }
		if (Input.GetKey("a")) { rigidBody.AddRelativeForce (Vector3.left * speed); }
		if (Input.GetKey("d")) { rigidBody.AddRelativeForce (Vector3.right * speed); }
		if (Input.GetKey("z")) { rigidBody.AddRelativeForce (Vector3.down * speed); }
		if (Input.GetKey("x")) { rigidBody.AddRelativeForce (Vector3.up * speed); }
		if (Input.GetAxis("Mouse X")!=0) {
			rigidBody.AddRelativeTorque( 0, Input.GetAxis("Mouse X") * mouseSensativity, 0);
		}
		if (Input.GetAxis("Mouse Y")!=0) {
			rigidBody.AddRelativeTorque( invertPitchInt * Input.GetAxis("Mouse Y") * mouseSensativity, 0, 0); 
		}
		if (Input.GetKey("q")) {
			rigidBody.AddRelativeTorque(0, 0, speed * Time.deltaTime * 20);
		}
		if (Input.GetKey("e")) {
			rigidBody.AddRelativeTorque(0, 0, -speed * Time.deltaTime * 20);
		}
		rigidBody.velocity = rigidBody.velocity*0.986f;

	}

    private void Update()
    {
        if (Input.GetButton("Fire1")&&Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn1.position, transform.rotation);
			Instantiate(shot, shotSpawn2.position, transform.rotation);
			audioDisparo.Play ();
        }
    }
}
