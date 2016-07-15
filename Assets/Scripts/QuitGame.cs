using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {
	
	void OnTouchDown()
	{
		Application.Quit ();
	}
}
