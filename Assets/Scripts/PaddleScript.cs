using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour {
	public static PaddleScript main;
	public float speed=1;

	float inSpeed = 0 ;
	public Vector3 direction ;
	Vector3 move;
	public bool moving = false;

	void Awake () {
		main = this;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("a") && Input.GetKey ("d")) {
			moving = false;
			return;
		} else if (Input.GetKey ("a")) {
			inSpeed = -speed;
			moving = true;
		} else if (Input.GetKey ("d")) {
			inSpeed = speed;
			moving = true;
		} else {
			moving = false;
			return;
		}
		//Debug.Log (inSpeed);
	//	Debug.Log (CanMove());
		if (CanMove ()){
			moving = true;
		//	Debug.Log ("in:");
			direction = new Vector3 (inSpeed, 0, 0);
			transform.position += delta;
		}
		else
			moving = false;
			//	transform.position -= delta;

	}
	bool CanMove(){

		if (Input.GetKey ("d") && ((transform.localScale.x * .5 )+ (transform.position.x) + (delta.x ) )> 10 ){
			return false;
		}
		else if  (Input.GetKey ("a") && ((-transform.localScale.x * .5 )+ transform.position.x + delta.x )< -10){
			return false;
		}
		else{
			return true;
		}
	}
	public Vector3 delta {
		get {
			return Time.deltaTime * direction;
			
		}
	}
}
