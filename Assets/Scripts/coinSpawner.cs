using UnityEngine;
using System.Collections;

public class coinSpawner : MonoBehaviour {

	public Transform[] spawnPoints;
	public GameObject coin;
	public bool spawnCoins = false;
	// Update is called once per frame
	void Update () {

		if (!spawnCoins) {

			spawnCoin();

				}
	
	}

	void spawnCoin()
	{
		spawnCoins = true;
		Transform coinSpawnLocation = spawnPoints [Random.Range (0, spawnPoints.Length)];
		GameObject coinInstance = (GameObject)Instantiate (coin, coinSpawnLocation.position, coinSpawnLocation.rotation);
	}
}
