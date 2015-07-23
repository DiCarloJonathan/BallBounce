using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovePhisics : MonoBehaviour {

	public float howSideways = 1;
	public float horizontal;
	public float virticle;
	public float speed=1;
	PaddleScript paddle;
//	float rightl;
//	float leftl;
//	PaddleScript paddle;
	bool ballIsStuck = true;
	Vector3 forces; 
//	Vector3 paddleDir = Vector3.up;
	List<int> hits = new List<int>();
	// Use this for initialization
	void Start () {
		paddle = PaddleScript.main;
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
			for (int i=0; i< BrickControll.numBricks; i++)
				if (BrickControll.brick [i] != null)
					isBrick (transform.position);
			if (delta.x + transform.position.x >= 9.5 || delta.x + transform.position.x <= -9.5) {
				forces.x *= -1;

			}
			if (delta.y + transform.position.y >= 6.5) {
				forces.y *= -1;
			
			}
			if (delta.y + transform.position.y <= -9) {
				SpawnBall.reset = true;
				Destroy (gameObject);
			}
			/*if((delta.y + transform.position.y ) <= (paddle.transform.position.y + (paddle.transform.localScale.y * .5f)) && (delta.x + transform.position.x >=  ){

			}
			else*/
			if ((delta.y + transform.position.y - (transform.localScale.y * .5f)) <= (paddle.transform.position.y + (paddle.delta.y + paddle.transform.localScale.y * .5f)) &&
				((transform.position.y - (transform.localScale.y * .5f)) >= (paddle.transform.position.y + (paddle.transform.localScale.y * .5f))) &&
				((transform.position.x - .5f + delta.x) <= (paddle.transform.position.x + paddle.delta.x + paddle.transform.localScale.x * .5f) && 
				(transform.position.x + .5f + delta.x) >= paddle.transform.position.x + paddle.delta.x - (paddle.transform.localScale.x * .5f))) {

				float diff = (transform.position.x - paddle.transform.position.x / (paddle.transform.localScale.x / 2)) / 2;
				if (diff > 0)
					forces.y = 1 - diff;
				else	
					forces.y = 1 + diff;
				forces.x = diff;
				//	paddleDir.x += (transform.position.x - paddle.transform.position.x)* howSideways;
				//paddleDir.Normalize ();
				//forces = Vector3.Reflect (forces, paddleDir);
				forces.Normalize ();
			} else if ((delta.y + transform.position.y - .5 <= paddle.transform.position.y + paddle.transform.localScale.y * .5) &&
				(delta.y + transform.position.y + .5 >= paddle.transform.position.y - paddle.transform.localScale.y * .5) &&
				((delta.x + transform.position.x + .5 >= paddle.delta.x + paddle.transform.position.x - (.5 * paddle.transform.localScale.x)) &&
				(transform.position.x + .5 <= paddle.transform.position.x - (.5 * paddle.transform.localScale.x)))){
			        
				forces.x = -paddle.speed;
				forces.y*=20;
				forces.Normalize ();
			}
		 else if ((delta.y + transform.position.y - .5 <= paddle.transform.position.y + paddle.transform.localScale.y * .5) &&
			(delta.y + transform.position.y + .5 >= paddle.transform.position.y - paddle.transform.localScale.y * .5) &&
			((delta.x + transform.position.x - .5 <= paddle.delta.x + paddle.transform.position.x + (.5 * paddle.transform.localScale.x)) &&
			(transform.position.x - .5 >= paddle.transform.position.x + (.5 * paddle.transform.localScale.x)))) {
			forces.x = paddle.speed;
			forces.y*=20;
			forces.Normalize ();
			
		}
		} else if (paddle.moving == true && ballIsStuck == true)
			forces = paddle.direction / speed;
		else if(ballIsStuck == true)
			forces = Vector3.zero;	
	}
	void isBrick(Vector3 destination){
		int c1=0,c2=0;
		for (int i=0; i< BrickControll.numBricks; i++) {
			//Debug.Log ("for check "+i+" brick" + BrickControll.brick [i]);
			if (BrickControll.brick [i] != null) {
				if ((destination.x + delta.x + .5 >= BrickControll.brick [i].leftBound && destination.x + .5 <= BrickControll.brick [i].leftBound || destination.x + delta.x - .5 <= BrickControll.brick [i].rightBound && destination.x - .5 >= BrickControll.brick [i].rightBound) && destination.y + delta.y + .5 >= BrickControll.brick [i].lowerBound && destination.y + delta.y - .5 <= BrickControll.brick [i].uperBound) {
					if(c1==0){
						forces.x *= -1;
						c1++;
					}
					hits.Add (i);
				//	Debug.Log ("hitl" + i);
				}

	//	else if ((destination.x + delta.x + .5 >= brick.leftBound && destination.x +.5 <= brick.leftBound ) && destination.x -.5>= brick.rightBound && destination.y + delta.y  +.5 >= brick.lowerBound && destination.y + delta.y  -.5 <= brick.uperBound)
		//	forces.x *= -1;
				else if ((destination.x + delta.x + .5 >= BrickControll.brick [i].leftBound && destination.x + delta.x - .5 <= BrickControll.brick [i].rightBound) && (destination.y + delta.y + .5 >= BrickControll.brick [i].lowerBound && destination.y + .5 <= BrickControll.brick [i].lowerBound || (destination.y +delta.y - .5 <= BrickControll.brick [i].uperBound && destination.y - .5 >= BrickControll.brick [i].uperBound))) {
					if (c2==0){
						forces.y *= -1;
						c2++;
					}
					if (!hits.Contains (i)) {
						hits.Add (i);
					//	Debug.Log ("hitb" + i);
					}
				}
			}
		}
		c1 = 0;
		c2= 0;
	//	Debug.Log ("End For Check");
		if (hits != null) {
			foreach (int hit in hits){
			//	Debug.Log("hit check");
				if (BrickControll.brick[hit] != null){
					BrickControll.brick[hit].GotHit ();
		//		Debug.Log("damaged :"+hit);
				}
			}
			hits.Clear();
		}
	}
	Vector3 delta{
		get{
			return Time.deltaTime * speed * forces;
		}

	}
}