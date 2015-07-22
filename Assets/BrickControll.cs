using UnityEngine;
using System.Collections;

public class BrickControll : MonoBehaviour {

	public GameObject brickO;
	public int numberOfBricks=1;
	public static int numBricks=2;
	public static int whichBrick=0;
	Vector3 where = Vector3.zero;
	public static BrickBehavior [] brick;

	// Use this for initialization
	void Start () {
		brick = new BrickBehavior [numBricks];
		for (int i =0; i < numBricks; i++) {
			Instantiate (brickO, where, Quaternion.identity);
			brick[i] = BrickBehavior.main;
			where.x += 3;

		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
