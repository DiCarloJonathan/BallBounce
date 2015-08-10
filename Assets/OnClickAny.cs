using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnClickAny : MonoBehaviour {

	public Image ripple;
	public Vector2 finalSize = new Vector2 (200, 200);
	Vector2 size=new Vector2(0,0);
	bool doRipple = false;
	Vector2 moucePositon =new Vector2(0,0);

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			doRipple = true;
		//	moucePositon.x = Input.mousePosition.;
		//	moucePositon.y = Input.mousePosition.y;
			ripple.rectTransform.anchoredPosition = Input.mousePosition - new Vector3(467.5f,164.5f,0);
		}
		if(doRipple == true){
			ripple.rectTransform.sizeDelta = Vector2.Lerp(size, finalSize, .1f);
			size = ripple.rectTransform.sizeDelta;
			if (size.x >= (finalSize.x -2)){
				size = ripple.rectTransform.sizeDelta = new Vector2(0,0);
				doRipple = false;

			}
		}
	
	}
}
