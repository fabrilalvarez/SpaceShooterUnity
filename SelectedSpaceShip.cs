using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;


public class SelectedSpaceShip : MonoBehaviour
{

	public static SelectedSpaceShip instance = null;
	public GameObject[] spaceShips;

	static int price;

	public GameObject missile;
	public int munition;

	public static int coins = 100;

	public GameObject canvas;
	public GameObject cMissile;

	GameObject spaceShip;
	Rigidbody rb;

	static int position = 0;
	bool isOther = false;

	public static SelectedSpaceShip Instance ()
	{
		if (!instance) {
			instance = FindObjectOfType (typeof(SelectedSpaceShip)) as SelectedSpaceShip;
		}
		return instance;
	}

	/// <summary>
	/// Se ejecuta antes que el método Start()
	/// </summary>
	void Awake ()
	{ 

		//Chequea si la instancia ya existe
		if (instance == null) {
			//Metes esta instancia
			instance = this;
		}            
        //Si la instancia ya existe y no es esta:
        else if (instance != this) {
			//Entonces destruyes esta. Esto refuerza nuestro patrón único,
			//lo que significa que sólo puede haber nunca una instancia de una SelectedSpaceShip.
			Destroy (gameObject);
		}

		if (SceneManager.GetActiveScene ().name != "BASE") {
			canvas.SetActive (false);
			//Este gameObject no lo destruyas al recargar la escena.
			DontDestroyOnLoad (gameObject);
		}

		//Dependiendo el botón pulsado en la Scene "BASE", lo que hacemos es asignar una spaceShip. 
		spaceShip = spaceShips [position].gameObject;

		//Le damos un rigidBody para poder hacerla aparecer en el escenario
		rb = spaceShip.GetComponent<Rigidbody> ();

		// Hace aparecer la spaceShip.
		SpawnSpaceShip ();
	}

	void Update ()
	{
		if (SceneManager.GetActiveScene ().name != "BASE") {
			canvas.SetActive (false);
		} else {
			canvas.SetActive (true);
		}

		// Si es otra nave
		if (isOther == true && SceneManager.GetActiveScene ().name == "BASE") {
			//Dependiendo el botón pulsado en la Scene "BASE", lo que hacemos es asignar una spaceShip. 
			//Hacemos reaparecer la nave
			Awake ();   
			isOther = false;
		}
	}

	/// <summary>
	/// Hace aparecer la spaceShip.
	/// </summary>
	void SpawnSpaceShip ()
	{
		Vector3 positionSpaceship = new Vector3 (rb.position.x, 0.0f, rb.position.z);
		//Quaternion rotation = Quaternion.identity;
		Instantiate (spaceShip, positionSpaceship, Quaternion.identity);
	}

	public void MissileLauncher ()
	{
		Rigidbody rbm = missile.GetComponent <Rigidbody> ();
		Vector3 positionMissile = new Vector3 (rbm.position.x, 0.0f, rbm.position.z);
		if (munition > 0) {
			Instantiate (missile, positionMissile, Quaternion.identity);
			//if (audioSource.isActiveAndEnabled) {
			//	audioSource.Play ();
			//}
			munition--;
		}
	}

	public GameObject GetSpaceShip ()
	{
		return spaceShip;
	}

	public void SetIsOther (bool other)
	{
		isOther = other;
	}

	public void SetPosition (int pos)
	{
		position = pos;
	}

	public int GetCoins ()
	{
		return coins;
	}

	public void SetCoins (int coin)
	{
		coins = coin;
	}

	void OnGUI ()
	{
		GUI.Label (new Rect (25, 25, 600, 120), "Coins : " + coins);
		GUI.Label (new Rect (25, 275, 600, 120), "Munition : " + munition);
	}

}