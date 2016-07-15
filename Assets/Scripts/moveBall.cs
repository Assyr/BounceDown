using UnityEngine;
using System.Collections;


public class moveBall : MonoBehaviour {
	public float force = 25.0f;
	public Color trailColor;
	public Transform smokeEffect;

	public AudioSource ballCollisionSound;
	void Start()
	{
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		trailColor = gameObject.GetComponentInChildren<TrailRenderer>().renderer.material.color = trailColor;
	}
	
	//Physics update function
	void FixedUpdate()
	{	
		trailColor = new Color (Random.value, Random.value, Random.value);
		Vector2 direction = Vector2.zero;

        direction.x = 0.1f;
		//direction.x = Input.acceleration.x;
		//direction.y = -Input.acceleration.x;
		//direction.z = Input.acceleration.x;

		Debug.Log(this.gameObject.rigidbody.velocity);


        if (Input.GetMouseButtonDown(0))
            rigidbody.velocity = rigidbody.velocity.normalized * 17.00f;


		if (direction.sqrMagnitude > 1)
						direction.Normalize ();

		//rigidbody.velocity = constantVelocity * (rigidbody.velocity.normalized);
		rigidbody.AddForce(direction * force);
		transform.Rotate (direction * force);
	}
	/*
	void OnTriggerEnter(Collider info)
	{
		if (info.tag == "Platform 3")
						info.gameObject.renderer.material.color = trailColor;
						//info.renderer.material.color = trailColor;
	}*/


    void OnTouchDown()
    {
        rigidbody.velocity = rigidbody.velocity.normalized * 17.00f;
    }

	void OnCollisionEnter(Collision hit)
	{
		if (hit.gameObject) {
			Instantiate(smokeEffect, transform.position, transform.rotation);
				}
		ballCollisionSound.Play ();
		Handheld.Vibrate ();
	}

	void OnCollisionExit()
	{
		//iTween.ShakePosition (this.gameObject, iTween.Hash ("x", 0.1f, "time", 0.1f));
		gameObject.GetComponentInChildren<TrailRenderer> ().renderer.material.SetColor ("_TintColor", trailColor);
		rigidbody.velocity = rigidbody.velocity.normalized * 17.00f;

	}
}
