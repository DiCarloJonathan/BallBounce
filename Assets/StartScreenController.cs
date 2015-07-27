using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;

public class StartScreenController : MonoBehaviour {

	public GameObject butonHolder;
	public GameObject levels;
	public GameObject startScreen;
	public ToggleGroup levelSelect;
	public string whichLevel="Level?";

	void Awake(){
		Time.timeScale = 0;
	}

	public void lSBBehavior(){
		butonHolder.SetActive (false);
		levels.SetActive (true);
	}
	public void StartButton(){
		if (levelSelect.ActiveToggles () != null) {
			whichLevel = levelSelect.ActiveToggles ().FirstOrDefault ().tag;
		}
		if(whichLevel!="Level?"){
			SetLevel ();
			startScreen.SetActive (false);
			Time.timeScale = 1;
		}
	}
	void SetLevel(){
		switch(whichLevel)
		{
			case "Level1":
				BrickControll.level = new int[6,6]{
				{0,0,0,0,0,0},
				{0,0,2,0,0,0},
				{0,0,1,0,0,0},
				{0,0,1,0,0,0},
				{0,0,0,0,0,0},
				{1,1,1,1,1,2}};
				BrickControll.spawnBricks=true;
				break;
			case "Level2":
				BrickControll.level = new int[6,6]{
				{0,0,0,0,0,0},
				{0,0,2,0,0,0},
				{0,0,2,0,1,0},
				{0,0,2,0,0,0},
				{0,0,0,0,1,0},
				{0,0,0,0,0,0}};
				BrickControll.spawnBricks=true;
				break;
			default:
				break;
				

		}
	}
}
