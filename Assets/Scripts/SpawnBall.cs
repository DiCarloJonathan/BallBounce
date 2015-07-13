using UnityEngine;
using System.Collections;

public class SpawnBall : MonoBehaviour {

	public GameObject ball;

	public static bool reset = false;

	// Use this for initialization
	void Start () {
		Instantiate(ball ,Vector3.zero, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		if (reset == true) {
			//DestroyImmediate (ball,true);
			Instantiate(ball ,Vector3.zero, Quaternion.identity);
			reset =false;
		}
	}
}
