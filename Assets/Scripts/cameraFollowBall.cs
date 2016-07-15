using UnityEngine;
using System.Collections;

public class cameraFollowBall : MonoBehaviour {

	//Create a public transform which will hold our ball instance in our scene
	public Transform ball;

	public float smoothRate = 0.5f; //This is the tracking rate, this is used along with Mathf.SmoothDamp to move to the ball in a smooth fashion and not sharply.

	//This holds the cameras transform
	private Transform cameraTransform;

	//This holds the velocity in which the camera will move in, it holds the x velocity and y velocity
	private Vector2 velocity;

	//On start..
	// Use this for initialization
	void Start () {
		//Store the transform that this script is attached to (our camera) to camera transform
		cameraTransform = transform;

		//Define our 2dimensional velocity vector with a x and y vector velocity of 0.5f
		velocity = new Vector2 (0.5f, 0.5f);
	
	}
	//On update
	// Update is called once per frame
	void Update () {

		//Create a 2 dimensional vector called newPos and set it to 0 on the x and 0 on the y
		Vector2 newPos = Vector2.zero;

		//Set newPos.x and y to a return from smoothdamp with cameraTransform x and y, ball x and y, the velocity and the smooth rate (which will return a smooth follow
		newPos.x = Mathf.SmoothDamp (cameraTransform.position.x, ball.position.x, ref velocity.x, smoothRate);
		newPos.y = Mathf.SmoothDamp (cameraTransform.position.y, ball.position.y, ref velocity.y, smoothRate);

		//Create a 3 dimensional vector called vec3Pos which holds the Smoothdamped vector (newPos.x and newPos.y)
		Vector3 vec3Pos = new Vector3(newPos.x, newPos.y, transform.position.z);
		//Set the transform of the object this script attached to, to a return from slerp
		//What the below does is take the current camera transform, and the target transform (vec3Pos (AKA BALL LOCATION)) and tells it tmove to it according to a slerp (find out what slerp means later)
		transform.position = Vector3.Slerp (transform.position, vec3Pos, Time.time);
	}
}
