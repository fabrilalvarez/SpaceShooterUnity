using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Persistance : MonoBehaviour
{
	int coins;
	int position;

	public void Save ()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerConf.dat");

		PlayerData data = new PlayerData ();
		data.coins = coins;
		data.shipPosition = position;

		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load ()
	{
		if (File.Exists (Application.persistentDataPath + "/playerConf.dat")) {

			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerConf.dat", FileMode.Open);

			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();

			coins = data.coins;
			position = data.shipPosition;

		}
	}
}

[Serializable]
class PlayerData
{
	public int coins;
	public int shipPosition;
}
