using UnityEngine;
using System.Collections;

public class PlatformColor : MonoBehaviour {
	Camera gameCamera;
	public Color trailColor;

	// Use this for initialization
	void Start () {
		gameCamera = Camera.main.camera;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter()
	{
		iTween.ShakePosition (gameCamera.gameObject, iTween.Hash ("x", 1.0f, "time", 0.4f));
		iTween.ShakePosition (this.gameObject, iTween.Hash ("x", 0.7f, "time", 1.0f));
		renderer.material.color = new Color (Random.value, Random.value, Random.value);
		gameCamera.backgroundColor = new Color (Random.value, Random.value, Random.value);
		//info.renderer.material.color = trailColor;
	}
}
