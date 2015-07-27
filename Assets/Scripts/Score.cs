using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	public Text timeText;
	public static float timer=60;

	void Update () {
	/*	if ((int)timer==1)
			timeText.text = "Time to Finish: " + 1+" Second";
		else if ((int)timer < 60)
			timeText.text = "Time to Finish: " + (int)timer+" Seconds";
		else if ((int)timer % 60 == 0)
			timeText.text = "Time to Finish: " + (int)timer/60 +" Minutes";
		else if (timer > 60 && (int)timer%60 ==1)
			timeText.text = "Time to Finish: " + (int)timer/60 + " Minutes " + 1+ " second";
		else if (timer > 60)
			timeText.text = "Time to Finish: " + (int)timer/60 + " Minutes " + (int)timer%60+ " seconds";*/

		if((int)timer%60>9)
			timeText.text = "Time to Finish: " + (int)timer/60+":"+(int)timer%60;
		else
			timeText.text = "Time to Finish: " + (int)timer/60+":"+0+(int)timer%60;
		timer -= Time.deltaTime;
	
	}
}
