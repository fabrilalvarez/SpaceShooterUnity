using UnityEngine;
using System.Collections;
using System.Diagnostics;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public static int price;

	public float speed;
	public float tilt;
	public Boundary boundary;

	public Transform[] shotSpawns;
	public float fireRate;
	public GameObject shot;

	private float nextFire;

	private Quaternion calibrationQuaternion;
	private Rigidbody rb;
	private AudioSource audioSource;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();
		CalibrateAccelerometer ();
	}

	void Update ()
	{
		//Input.GetButton("Fire1")&&
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			foreach (var shotSpawn in shotSpawns) {
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			}
			if (audioSource.isActiveAndEnabled) {
				audioSource.Play ();
			}
		}
	}

	//Used to calibrate the Iput.acceleration input
	void CalibrateAccelerometer ()
	{
		Vector3 accelerationSnapshot = Input.acceleration;
		Quaternion rotateQuaternion = Quaternion.FromToRotation (new Vector3 (0.0f, 0.0f, -1.0f), accelerationSnapshot);
		calibrationQuaternion = Quaternion.Inverse (rotateQuaternion);
	}

	//Get the 'calibrated' value from the Input
	Vector3 FixAcceleration (Vector3 acceleration)
	{
		Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
		return fixedAcceleration;
	}

	void FixedUpdate ()
	{
		//float moveHorizontal = Input.GetAxis("Horizontal");
		//float moveVertical = Input.GetAxis("Vertical");
		//Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		//Vector2 direcction = new touchPad.GetDirection();

		Vector3 accelerationRaw = Input.acceleration;
		Vector3 acceleration = FixAcceleration (accelerationRaw);
		Vector3 movement = new Vector3 (acceleration.x * 2, 0.0f, acceleration.y);
		rb.velocity = movement * speed;

		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}
		
}