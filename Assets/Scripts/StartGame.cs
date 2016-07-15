using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	void Awake()
	{
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	void OnTouchDown()
	{
		Handheld.Vibrate ();
		Application.LoadLevel (1);
	}
}
