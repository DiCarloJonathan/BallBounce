using UnityEngine;
using System.Collections;

public class SpawnBall : MonoBehaviour {

	public GameObject ball;

	public static bool reset = true;
	Vector3 location;
	PaddleScript paddle;
	// Use this for initialization
	void Start () {
		paddle = PaddleScript.main;
	}
	
	// Update is called once per frame
	void Update () {
		if (reset == true) {
			if (paddle.moving == true)
				location = new Vector3((paddle.transform.position.x + paddle.delta.x), ((ball.transform.localScale.y * .5f) + paddle.transform.position.y + (paddle.transform.localScale.y * .5f)), 0);
			else 
				location = new Vector3((paddle.transform.position.x), ((ball.transform.localScale.y * .5f) + paddle.transform.position.y + (paddle.transform.localScale.y * .5f)), 0);
			Instantiate(ball ,location, Quaternion.identity);
			reset =false;
		}
	}
}
