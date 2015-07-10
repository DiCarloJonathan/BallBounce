using UnityEngine;
using System.Collections;

public class MovePhisics : MonoBehaviour {

	public float horizontal;
	public float virtical;
	public float speed=1;
	float coef;
//	float rightl;
//	float leftl;

	Vector3 forces;

	// Use this for initialization
	void Start () {
		forces = new Vector3 (horizontal, virtical, 0);
		coef = Time.deltaTime * speed;
	
	}
	// Update is called once per frame
	void Update () {
		ChangeDirections();
			transform.position += forces * coef;

	}
	void ChangeDirections(){
		if (transform.position.x + horizontal * coef >= 9.5 || transform.position.x + horizontal * coef <= -9.5)
			horizontal = horizontal * -1;
		if (transform.position.y + virtical * coef >= 6.5 || transform.position.y + virtical * coef <= -6.5)
			virtical = virtical * -1;
		forces = new Vector3 (horizontal, virtical, 0);
	}
}
