using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	public Text timeText;
	float timer=0;

	void Update () {
		timeText.text = "Time Elapsed: " + (int)timer+" Seconds"; 
		timer += Time.deltaTime;
	
	}
}
