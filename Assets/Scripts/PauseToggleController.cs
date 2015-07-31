using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseToggleController : MonoBehaviour {
		public Text pButtonT;
		public GameObject pauseScreen;
		
		static public bool paused =false;
		
		float isPaused;
		
		void Start(){
			isPaused = 2;
		}
		
		public void pause(){
			if (isPaused % 2 == 0){
				
				paused = true;
				Time.timeScale=0;
				pButtonT.text="Unpause";
				pauseScreen.SetActive(true);
				
			}
			else{
				Time.timeScale = 1;
				pButtonT.text="Pause";
				paused = false;
				pauseScreen.SetActive(false);
				
				
			}
			if (isPaused >= 3)	
				isPaused = 1;
			isPaused += 1;
	}
	
}
