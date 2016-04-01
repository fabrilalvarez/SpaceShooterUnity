using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Market : MonoBehaviour
{
	
	static bool[] purchased;
	int coins;

	SelectedSpaceShip sp;

	// Use this for initialization
	void Start ()
	{
		sp = SelectedSpaceShip.Instance ();
		coins = sp.GetCoins ();
	}

	public void Pruebas ()
	{
		if (purchased [0] == false) {
			if (sp.GetCoins () >= PlayerController.price) {
				Destroy (GameObject.Find (sp.GetSpaceShip ().name + "(Clone)"));
				sp.SetPosition (0);
				sp.SetIsOther (true);
				//sp.GetCoins () -= PlayerController.price;
				purchased [0] = true;
			}  
		} else if (purchased [0]) {
			Destroy (GameObject.Find (sp.GetSpaceShip ().name + "(Clone)"));
			sp.SetPosition (0);
			sp.SetIsOther (true);
		}
		//Save ();
	}

	public void Buy0 ()
	{
		if (sp.GetCoins () >= 10) {
			Destroy (GameObject.Find (sp.GetSpaceShip ().name + "(Clone)"));
			sp.SetPosition (0);
			sp.SetIsOther (true);
			sp.SetCoins (coins -= 10);
		} 
	}

	public void Buy1 ()
	{
		if (sp.GetCoins () >= 10) {
			Destroy (GameObject.Find (sp.GetSpaceShip ().name + "(Clone)"));
			sp.SetPosition (1);
			sp.SetIsOther (true);
			sp.SetCoins (coins -= 10);
		} 
	}

	public void Buy2 ()
	{
		if (sp.GetCoins () >= 20) {
			Destroy (GameObject.Find (sp.GetSpaceShip ().name + "(Clone)"));
			sp.SetPosition (2);
			sp.SetIsOther (true);
			sp.SetCoins (coins -= 20);
		}
	}

	public void Buy3 ()
	{
		if (sp.GetCoins () >= 30) {
			Destroy (GameObject.Find (sp.GetSpaceShip ().name + "(Clone)"));
			sp.SetPosition (3);
			sp.SetIsOther (true);
			sp.SetCoins (coins -= 30);
		}
	}

	public void Buy4 ()
	{
		Destroy (GameObject.Find (sp.GetSpaceShip ().name + "(Clone)"));
		sp.SetPosition (4);
		sp.SetIsOther (true);
	}

	public void Buy5 ()
	{
		Destroy (GameObject.Find (sp.GetSpaceShip ().name + "(Clone)"));
		sp.SetPosition (5);
		sp.SetIsOther (true);
	}

	public void Buy6 ()
	{
		Destroy (GameObject.Find (sp.GetSpaceShip ().name + "(Clone)"));
		sp.SetPosition (6);
		sp.SetIsOther (true);
	}

	public void Buy7 ()
	{
		Destroy (GameObject.Find (sp.GetSpaceShip ().name + "(Clone)"));
		sp.SetPosition (7);
		sp.SetIsOther (true);
	}

	public void Buy8 ()
	{
		Destroy (GameObject.Find (sp.GetSpaceShip ().name + "(Clone)"));
		sp.SetPosition (8);
		sp.SetIsOther (true);
	}

	public void BuyMissile ()
	{
		if (coins > 0) {
			sp.munition += 1;
			sp.SetCoins (coins -= 1);
		}
	}

	public void Back ()
	{
		SceneManager.LoadScene ("MENU");
	}
}
