using UnityEngine;
using System.Collections;

public class BrickControll : MonoBehaviour {

	public GameObject brickO;
	public GameObject brick2;
	public int[,] level = new int[6,6]{
		{0,0,0,0,0,0},
		{0,0,2,0,0,0},
		{0,0,1,0,0,0},
		{0,0,1,0,0,0},
		{0,0,0,0,0,0},
		{1,1,1,1,1,2}};
	public static int numBricks;
	public static int whichBrick=0;
	Vector3 where = Vector3.zero;
	public static BrickBehavior [] brick;

	// Use this for initialization
	void Awake(){
	
	}
	void Start () {
		int cou=0;
		for (int i=0; i<6; i++)
			for (int j=0; j<6; j++)
				if (level [i, j] != 0)
					numBricks++;
		where.x = -6;
		where.y = 6;
		brick = new BrickBehavior [numBricks];
		//for (int i =0; i < numBricks; i++) {
		for (int i=0; i<6; i++)
			for (int j=0; j<6; j++) {
				where.x += 2*j ;
				where.y -= i;
				if (level [i, j] == 1) {
					Instantiate (brickO, where, Quaternion.identity);
					brick [cou] = BrickBehavior.main;
				cou++;
				}
				if (level [i, j] == 2) {
					Instantiate (brick2, where, Quaternion.identity);
					brick [cou] = BrickBehavior.main;
					cou++;
				}
				where.x = -6;
				where.y = 6;
			}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
