using UnityEngine;
using System.Collections;

public class BrickBehavior : MonoBehaviour {

	public static BrickBehavior main;
	public int durability = 1; 
	public float collorChange;

	public int cR=0 ,cG=0,cB=0,cA=255;
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
		brickColl.color = new Color32((byte)(cR * durability), (byte)(cG* durability),(byte)(cB* durability), (byte)(cA));
		curentCollor = brickColl.color;
		uperBound = (float)(transform.position.y + (transform.localScale.y * .5));
		lowerBound = (float)(transform.position.y - (transform.localScale.y * .5));
		leftBound = (float)(transform.position.x - (transform.localScale.x * .5));
		rightBound = (float)(transform.position.x + (transform.localScale.x * .5));
	//	Debug.Log (curentCollor.r );
	}

	public void GotHit(){
		//Debug.Log (curentCollor.r -collorChange);
		//Debug.Log ("befor: " + curentCollor.r );
		//Debug.Log ("After: " + curentCollor.r );
		if (durability <= 1) {
			Destroy(gameObject);
		} else{
			//collor change
			durability -= 1;
			brickColl.color = new Color32((byte)(curentCollor.r -collorChange), (byte)(curentCollor.g -collorChange),(byte)(curentCollor.r -collorChange), (byte)cA);
			colorSet();
			return;
		}

		
	}

	void colorSet(){
		if(curentCollor.r - collorChange>=0)
				curentCollor.r = (byte)(curentCollor.r - collorChange);
			if(curentCollor.g - collorChange>=0)
				curentCollor.g = (byte)(curentCollor.g - collorChange);
			if(curentCollor.b - collorChange>=0)
				curentCollor.b = (byte)(curentCollor.b - collorChange);

	}
}
