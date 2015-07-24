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
			inSpeed =0;
			//direction = new Vector3 (0, 0, 0);
			moving = false;
		} else if (Input.GetKey ("a")) {
			inSpeed = -speed;
			//direction = new Vector3 (-speed, 0, 0);
			moving = true;
		} else if (Input.GetKey ("d")) {
			inSpeed =speed;
		//	direction = new Vector3 (speed, 0, 0);
			moving = true;
		} else {
			Debug.Log ("flag");
			inSpeed =0;
		//	direction = new Vector3 (0, 0, 0);
			moving = false;
		}
	
		if (CanMove ()) {
			direction = new Vector3 (inSpeed, 0, 0);
			//direction.Normalize();
			transform.position += delta;
			Debug.Log ("can move");
		} else {
			//direction = new Vector3 (0, 0, 0);
			moving = false;
			direction = new Vector3 (0, 0, 0);
		//	Debug.Log("can't move");
			//	transform.position -= delta;
		}
	
	}


	bool CanMove(){

		if (Input.GetKey ("d") && ((transform.localScale.x * .5 )+ (transform.position.x) + (delta.x ) )>= 10 ){
			return false;
		}
		else if  (Input.GetKey ("a") && ((-transform.localScale.x * .5 )+ transform.position.x + delta.x )<= -10){
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
