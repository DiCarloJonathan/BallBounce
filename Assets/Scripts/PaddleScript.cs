using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour {
	public static PaddleScript main;
	// Use this for initialization
	public float speed=1;

	float inSpeed = 0 ;
	Vector3 direction ;
	Vector3 move;

	void Awake () {
		main = this;
	}
	void Start(){
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("a") && Input.GetKey ("d"))
			return;
		else if (Input.GetKey ("a")) {
			inSpeed = -speed;
		} else if (Input.GetKey ("d"))
			inSpeed = speed;
		else 
			return;
		//Debug.Log (inSpeed);
		Debug.Log (CanMove());
		if (CanMove ()){
			Debug.Log ("in:");
			direction = new Vector3 (inSpeed, 0, 0);
			transform.position += delta;
		}
	//	else
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
	Vector3 delta {
		get {
			return Time.deltaTime * direction;
			
		}
	}
}
