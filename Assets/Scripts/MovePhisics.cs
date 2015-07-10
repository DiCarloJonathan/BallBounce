using UnityEngine;
using System.Collections;

public class MovePhisics : MonoBehaviour {

	public float horizontal;
	public float virticle;
	public float speed=1;
//	float rightl;
//	float leftl;

	Vector3 forces;

	// Use this for initialization
	void Start () {
		forces = new Vector3 (horizontal, virticle, 0);
	
	}
	// Update is called once per frame
	void Update () {
		ChangeDirections();
		transform.position += delta;

	}
	void ChangeDirections(){
		if (delta.x + transform.position.x  >= 9.5 || delta.x + transform.position.x <= -9.5)
			forces.x *= -1;
		if (delta.y + transform.position.y >= 6.5 || delta.y + transform.position.y <= -6.5)
			forces.y *= -1;
	}
	Vector3 delta{
		get{
			return Time.deltaTime * speed * forces;

		}
	}
}
