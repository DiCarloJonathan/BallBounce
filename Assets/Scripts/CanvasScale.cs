﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class CanvasScale : MonoBehaviour {

	public GameObject game;
	Vector3 diference;
	float delta;
	float distance;
	float lastDistance;
	Vector3 followGame;
	float del = 0;
	Vector3 deltaUse= new Vector3 (0,0,0);
	Vector3 rot = new Vector3(0,180,0);


	public Transform target;
	RectTransform canvasRect;

	void Start(){
		canvasRect = this.GetComponent <RectTransform> ();
		del= transform.position.y;

		lastDistance = Vector3.Distance (transform.position, target.position);
	}
	
	void Update() {
		// Rotate the camera every frame so it keeps looking at the target
		transform.LookAt(target);
		transform.Rotate (rot);

		distance = Vector3.Distance (transform.position, target.position);
		delta = distance - lastDistance;
		del += delta*.6f;

		followGame = game.transform.position;
		followGame.y += del;
		transform.position = followGame;


		deltaUse.x = (delta*.002f);
		deltaUse.y = (delta*.002f);
	
		canvasRect.localScale += deltaUse;
		lastDistance = distance;

	}
}
