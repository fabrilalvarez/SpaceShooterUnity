using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public static GameController instance;

	public GameObject[] hazards;
	public Vector3 spawnValues;

	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public int score;
	public float extraScore;

	public Text scoreText;
	public Text gameOverText;
	public GameObject restartButton;

	private bool gameOver;

	public static GameController Instance ()
	{
		if (!instance) {
			instance = FindObjectOfType (typeof(GameController)) as GameController;
		}
		return instance;
	}

	void Start ()
	{
		gameOver = false;
		restartButton.SetActive (false);
		gameOverText.text = "";

		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

		}
	}

	public void RestartButton ()
	{
		if (gameOver) {
			restartButton.SetActive (true);
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = SceneManager.GetActiveScene ().name + " Score: " + score * extraScore;  
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}

	public void TitleLevel (string titleLevel)
	{
		gameOverText.text = titleLevel;
		gameOver = false;
	}

	public void RestartGame ()
	{
		if (score < 850) {
			SceneManager.LoadScene ("Level 1");
		}
		if (score >= 850) {
			SceneManager.LoadScene ("Level 2");
		}
		if (score >= 2125) {
			SceneManager.LoadScene ("Level 3");
		}
		if (score >= 3250) {
			SceneManager.LoadScene ("Level 4");
		}
		if (score >= 3500) {
			SceneManager.LoadScene ("Level 5");
		}
		if (score >= 3600) {
			SceneManager.LoadScene ("Level 6");
		}
	}
}