using UnityEngine;
using System.Collections;

public class TimeText : MonoBehaviour {

	public GUIText timeText;
	//int currScore;
	public float initTimer = 30.00f;
	public float timer = 30.00f;

	private static int score;


	void Start()
	{
	}


	// Update is called once per frame
	void Update () {
				score = coinCollect.currScore;
				timer -= Time.deltaTime;
				timeText.text = "Time Remaining: " + timer.ToString ("0.00");


		if (timer <= 0 && coinCollect.currScore < 5) {
			timeText.text = "YOU LOSE! You failed to achieve any medal - TAP TO RESTART";
			Time.timeScale = 0; //PAUSE ALL GAME TIME.
			for (int i = 0; i < Input.touchCount; i++) {
				Touch touch = Input.GetTouch (i);
				if (touch.phase == TouchPhase.Ended && touch.tapCount == 1) {
					Vector3 position = Camera.main.ScreenToWorldPoint (touch.position);
					Application.LoadLevel (1);
					timer = 30.00f;
					coinCollect.currScore = 0;
					Time.timeScale = 1;
					Update ();
				}
			}
		}

				if (timer <= 0 && coinCollect.currScore >= 5 && coinCollect.currScore < 10) {
						timeText.text = "YOU WIN! You've achieved the Bronze Medal - TAP TO RESTART";
						Time.timeScale = 0; //PAUSE ALL GAME TIME.
						for (int i = 0; i < Input.touchCount; i++) {
								Touch touch = Input.GetTouch (i);
								if (touch.phase == TouchPhase.Ended && touch.tapCount == 1) {
										Vector3 position = Camera.main.ScreenToWorldPoint (touch.position);
										Application.LoadLevel (1);
										timer = 30.00f;
										coinCollect.currScore = 0;
										Time.timeScale = 1;
										Update ();
								}
						}
				}

			if (timer <= 0 && coinCollect.currScore >= 10 && coinCollect.currScore < 15) 
				{
			timeText.text = "YOU WIN! You've achieved the Silver Medal - TAP TO RESTART";
			Time.timeScale = 0;
			for(int i = 0; i < Input.touchCount; i++)
			{
				Touch touch = Input.GetTouch(i);
				if(touch.phase == TouchPhase.Ended && touch.tapCount == 1)
				{
					Vector3 position = Camera.main.ScreenToWorldPoint(touch.position);
					Application.LoadLevel(1);
					timer = 30.00f;
					coinCollect.currScore = 0;
					Time.timeScale = 1;
					Update();
				}
			}
		}
		if (timer <= 0 && coinCollect.currScore >= 20) 
		{
			timeText.text = "YOU WIN! You've achieved the Gold Medal - TAP TO RESTART";
			Time.timeScale = 0;
			for(int i = 0; i < Input.touchCount; i++)
			{
				Touch touch = Input.GetTouch(i);
				if(touch.phase == TouchPhase.Ended && touch.tapCount == 1)
				{
					Vector3 position = Camera.main.ScreenToWorldPoint(touch.position);
					Application.LoadLevel(1);
					timer = 30.00f;
					coinCollect.currScore = 0;
					Time.timeScale = 1;
					Update();
				}
			}
		}


	}
}