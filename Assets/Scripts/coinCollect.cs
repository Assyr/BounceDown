using UnityEngine;
using System.Collections;

public class coinCollect : MonoBehaviour {

	//Update GUIText for score

	public GUIText score;
	public static int currScore;
	public coinSpawner spawnCoin;
	public TimeText incrementTime;
	public ParticleSystem confetti;
	public GameObject ballSpawn;
	Vector3 spawnPoint = new Vector3 (9, 40, 0);


	public GUITexture bronze;
	public GUITexture silver;
	public GUITexture gold;

	public AudioSource coinCollectSound;


	void Start()
	{
		confetti.Stop ();
		confetti.Clear ();
		bronze.enabled = false;
		silver.enabled = false;
		gold.enabled = false;
	}
	
	void Update()
	{
		score.text = "Score: " + currScore + "/5 for Bronze Medal";
		if (currScore >= 5 && currScore < 10) {
			score.text = "Score: " + currScore + "/10 for Silver Medal";
			bronze.enabled=true;
				}
		else if (currScore >= 10 && currScore < 20)
		{
			score.text = "Score: " + currScore + "/20 for Gold Medal";
			silver.enabled=true;
		}
		else if (currScore >= 20) {
			score.text = "Score: " + currScore;
			bronze.enabled=false;
			silver.enabled=false;
				gold.enabled=true;
				}
	}

	//Check for collision between ball and coin

	//On trigger (collision)
	void OnTriggerEnter(Collider coin)
	{//Our parameter will hold the instance of our ball to run checks with later
				//Check if what we collided with is the Ball
				if (coin.gameObject.tag == "Coin") {
			confetti.gameObject.transform.position = coin.gameObject.transform.position;
						confetti.Play ();
						//Destroy game object this is attached to
						Handheld.Vibrate();
						coinCollectSound.Play ();
						Destroy (coin.gameObject);
						++currScore;
						incrementTime.timer += 6.00f;
						//Spawn a new coin
						spawnCoin.spawnCoins = false;
				}
		//Instantiate(ballSpawn, spawnPoint, transform.rotation);
		}

}
