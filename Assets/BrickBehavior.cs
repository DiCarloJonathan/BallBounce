using UnityEngine;
using System.Collections;

public class BrickBehavior : MonoBehaviour {

	public static BrickBehavior main;
	public int durability = 1; 

	// Use this for initialization
	void Awake () {
		main = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GotHit(){
		durability -= 1;
		if (durability > 0) {
			//collor change
			return;
		} else {
			Destroy(gameObject);
		}
		
	}
}
