using UnityEngine;
using System.Collections;

public class BrickBehavior : MonoBehaviour {

	public static BrickBehavior main;
	public int durability = 1; 
	public float collorChange;

	public float uperBound;
	public float lowerBound;
	public float leftBound;
	public float rightBound;

	public Renderer rend;

	Material brickColl;
//	Shader shadeCol;
	Color32 curentCollor;

	// Use this for initialization
	void Awake () {
		main = this;
		rend = GetComponent <Renderer> ();
		rend.enabled = true;
		brickColl =rend.material;//new Material (Shader.Find("brick")); 
		brickColl.color = new Color32((byte)(collorChange * durability), (byte)0,(byte)0, (byte)255);
		curentCollor = brickColl.color;
		uperBound = (float)(transform.position.y + (transform.localScale.y * .5));
		lowerBound = (float)(transform.position.y - (transform.localScale.y * .5));
		leftBound = (float)(transform.position.x - (transform.localScale.x * .5));
		rightBound = (float)(transform.position.x + (transform.localScale.x * .5));
		Debug.Log (curentCollor.r );
	}

	public void GotHit(){
		Debug.Log (curentCollor.r -collorChange);
		Debug.Log ("befor: " + curentCollor.r );
		durability -= 1;
		brickColl.color = new Color32((byte)(curentCollor.r -collorChange), (byte)0,(byte)0, (byte)255);
		curentCollor.r = (byte)(curentCollor.r - collorChange);
		Debug.Log ("After: " + curentCollor.r );
		if (durability > 0) {
			//collor change
			return;
		} else {
			Destroy(gameObject);
		}
		
	}
}
