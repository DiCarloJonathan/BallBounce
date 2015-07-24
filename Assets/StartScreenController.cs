using UnityEngine;
using System.Collections;

public class StartScreenController : MonoBehaviour {

	public GameObject butonHolder;
	public GameObject levels;
	public GameObject startScreen;

	void Awake(){
		Time.timeScale = 0;
	}

	public void lSBBehavior(){
		butonHolder.SetActive (false);
		levels.SetActive (true);
	}
	public void StartButton(){
		startScreen.SetActive (false);
		Time.timeScale = 1;
	}
	void LoadLevel(){

	}
	public void SetLevel(){

	}
}
