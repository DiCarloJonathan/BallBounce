using UnityEngine;
using System.Collections;

public class RectValueContainer : MonoBehaviour {
	public Vector2 position = Vector2.zero;
	public Vector2 size = Vector2.zero;
	public Vector2 anchorMin = new Vector2(.5f, .5f);
	public Vector2 anchorMax = new Vector2(.5f, .5f);

	void SetValues(Vector2 pos, Vector2 siz, Vector2 anMin, Vector2 anMax ){
		size = siz;
		anchorMin = anMin;
		anchorMax = anMax;
		position = pos;
	}
}
