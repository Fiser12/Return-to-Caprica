using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody rig;
    public GameObject shot;
    public Transform shotSpawn1;
	public Transform shotSpawn2;

    public int speed;
    public int till;
	public float nextFire;
	public float fireRate;
	private float xPoint;
	private float yPoint;
	private AudioSource audioDisparo;
	void Start(){
	}
    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
		audioDisparo = GetComponent<AudioSource>();

    }
    private void FixedUpdate()
    {
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
		xPoint = (((Input.mousePosition.x)/Screen.currentResolution.width)*2-1)*1.5f;
		yPoint = (((Input.mousePosition.y)/Screen.currentResolution.height)*2-1)*1.5f;
		Vector3 movimiento;

		movimiento = new Vector3 (xPoint, yPoint, 1f);
		rig.velocity = movimiento * speed;
		transform.rotation = Quaternion.LookRotation (rig.velocity);
    }
}
