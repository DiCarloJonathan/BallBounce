using UnityEngine;
using System.Collections;

public class MovePhisics : MonoBehaviour {

	public float howSideways = 1;
	public float horizontal;
	public float virticle;
	public float speed=1;
	public int numBricks=2;
	PaddleScript paddle;
	BrickBehavior [] brick;
//	float rightl;
//	float leftl;
//	PaddleScript paddle;
	bool ballIsStuck = true;
	Vector3 forces; 
	Vector3 paddleDir = Vector3.up;
	// Use this for initialization
	void Start () {
		paddle = PaddleScript.main;
		brick = new BrickBehavior [numBricks];
		for(int i=0; i< numBricks; i++)
			brick[i] = BrickBehavior.main;
		forces = new Vector3 (horizontal, virticle, 0);
	
	}
	// Update is called once per frame
	void Update () {
		ChangeDirections();
		if (Input.GetKey ("space") && ballIsStuck == true) {
			ballIsStuck = false;
			forces = new Vector3(0,1,0);
		}
	//	Debug.Log (delta);
		transform.position += delta;

	}
	void ChangeDirections(){
		if (ballIsStuck == false) {
			for(int i=0; i< numBricks; i++)
				if (brick[i] != null)
					isBrick(transform.position);
			if (delta.x + transform.position.x >= 9.5 || delta.x + transform.position.x <= -9.5){
				forces.x *= -1;

			}
			if (delta.y + transform.position.y >= 6.5){
				forces.y *= -1;
			
			}
			if (delta.y + transform.position.y <= -6.5) {
				SpawnBall.reset = true;
				Destroy (gameObject);
			}
		/*	if((delta.y + transform.position.y ) <= (paddle.transform.position.y + (paddle.transform.localScale.y * .5f)) && (delta.x + transform.position.x >=  ){

			}
			else if*/if ((delta.y + transform.position.y - (transform.localScale.y * .5f)) <= (paddle.transform.position.y + (paddle.delta.y + paddle.transform.localScale.y * .5f)) && ((transform.position.x - .5f + delta.x) <=( paddle.transform.position.x + paddle.delta.x + paddle.transform.localScale.x * .5f) && (transform.position.x + .5f + delta.x) >= paddle.transform.position.x + paddle.delta.x - (paddle.transform.localScale.x * .5f))) {

				//		float diff = (transform.position.x - paddle.transform.position.x / (paddle.transform.localScale.x /2))/2;
				//		forces.y = 1- diff;
				//	forces.x = diff ;
				paddleDir.x += (transform.position.x - paddle.transform.position.x)* howSideways;
				paddleDir.Normalize ();
				forces = Vector3.Reflect (forces, paddleDir);
				forces.Normalize ();


			}
		} else if (paddle.moving == true)
			forces = paddle.direction / speed;
		else {
			forces = Vector3.zero;	
		}
	}
	void isBrick(Vector3 destination){
		int hit = -1;
		for(int i=0; i< numBricks; i++)
			if ((destination.x + delta.x + .5 >= brick[i].leftBound && destination.x + .5 <= brick[i].leftBound || destination.x + delta.x - .5 <= brick[i].rightBound && destination.x - .5 >= brick[i].rightBound) && destination.y + delta.y + .5 >= brick[i].lowerBound && destination.y + delta.y - .5 <= brick[i].uperBound) {
				forces.x *= -1;
				hit=i;
			}
	//	else if ((destination.x + delta.x + .5 >= brick.leftBound && destination.x +.5 <= brick.leftBound ) && destination.x -.5>= brick.rightBound && destination.y + delta.y  +.5 >= brick.lowerBound && destination.y + delta.y  -.5 <= brick.uperBound)
		//	forces.x *= -1;
			else if ((destination.x + delta.x + .5 >= brick[i].leftBound && destination.x + delta.x - .5 <= brick[i].rightBound) && (destination.y + delta.y + .5 >= brick[i].lowerBound && destination.y + .5 <= brick[i].lowerBound || (destination.y - .5 <= brick[i].uperBound && destination.y - .5 >= brick[i].lowerBound))){
				forces.y *= -1;
				hit = i;
			}
		if (hit != -1) {
			for(int i=0; i< numBricks; i++)
				brick[hit].GotHit ();
			hit = -1;
		}
	}
	Vector3 delta{
		get{
			return Time.deltaTime * speed * forces;
		}

	}
}