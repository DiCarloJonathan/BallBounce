using UnityEngine;
using System.Collections;

public class MovePhisics : MonoBehaviour {

	public float howSideways = 1;
	public float horizontal;
	public float virticle;
	public float speed=1;
	PaddleScript paddle;
//	float rightl;
//	float leftl;
//	PaddleScript paddle;
	Vector3 forces; 
	// Use this for initialization
	void Start () {
		paddle = PaddleScript.main;
		forces = new Vector3 (horizontal, virticle, 0);
	
	}
	// Update is called once per frame
	void Update () {
		ChangeDirections();
		transform.position += delta;

	}
	void ChangeDirections(){
		if (delta.x + transform.position.x >= 9.5 || delta.x + transform.position.x <= -9.5)
			forces.x *= -1;
		if (delta.y + transform.position.y >= 6.5)
			forces.y *= -1;
		if (delta.y + transform.position.y <= -6.5) {
			SpawnBall.reset = true;
			Destroy (gameObject);
		}		
		if ((delta.y + transform.position.y - transform.localScale.y * .5) <= (paddle.transform.position.y + paddle.transform.localScale.y * .5) && (transform.position.x - .5 <= paddle.transform.position.x + paddle.transform.localScale.x * .5 && transform.position.x + .5 >= paddle.transform.position.x - paddle.transform.localScale.x * .5)){
			float diff = (transform.position.x - paddle.transform.position.x / (paddle.transform.localScale.x /2))/2;
			forces.y = 1- diff;
			forces.x = diff ;

		}
	}
	Vector3 delta{
		get{
			return Time.deltaTime * speed * forces * howSideways;
		}

	}
}