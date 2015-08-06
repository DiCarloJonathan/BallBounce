using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

	public float speedR=1;
	public float speedFB=1;
	public GameObject camRigM;
	void FixedUpdate()
	{
		
		
		if (Input.GetKey ("a")) {
			transform.Rotate(0f,speedR ,0f);
		}
		if (Input.GetKey ("d")) {
			transform.Rotate(0f,-speedR ,0f);
		}
		if (Input.GetKey ("w") && camRigM.transform.position.y >= -10) {
			camRigM.transform.Translate(0f,.5f*-speedFB,-speedFB );
		}
		if (Input.GetKey ("s") && camRigM.transform.position.y <= 25) {
			camRigM.transform.Translate (0f, (.5f*speedFB), speedFB);
		}
	}
}
