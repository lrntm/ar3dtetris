﻿using UnityEngine;
using System.Collections;
using System;

public class GameController : MonoBehaviour {

	public GameObject I;
	public GameObject L;
	public GameObject S;
	public GameObject T;
	public GameObject Square;

	public GameObject ground;

	float startTime;

	public static GameObject activeBrick;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		createBrick();

	}
	
	// Update is called once per frame
	void Update () {
		
		float endTime = Time.time;
		float time = endTime - startTime;
		if (time > 5) {
			if (activeBrick != null) {
				activeBrick.tag = "Untagged";
			}
			Rigidbody r = activeBrick.GetComponents<Rigidbody> ()[0];
			r.useGravity = true;
			createBrick ();
			startTime = Time.time;
		}

	}

	public void createBrick(){

		if (activeBrick != null) {
			activeBrick.tag = "Untagged";
		}

		System.Random r = new System.Random ();
		int number = r.Next (1, 6);
		GameObject n = null;
		if (number == 1) {
			n = Instantiate (I);

		} else if (number == 2) {
			n = Instantiate (L);

		} else if (number == 3) {
			n = Instantiate (S);

		} else if (number == 4) {
			n = Instantiate (T);

		} else if (number == 5) {
			n = Instantiate (Square);

		}
		n.transform.parent = ground.transform;
		n.AddComponent <L_Shape>();

		n.tag = "active";
		activeBrick = n;
	}


	void mySelect(Touch touch){
		GameObject[] temp = GameObject.FindGameObjectsWithTag("active");
		if (temp.Length > 0) {
			activeBrick = temp [0];
			Rigidbody r = activeBrick.GetComponents<Rigidbody> ()[0];
			r.useGravity = true;
		}

		createBrick ();
		
	}

	private void OnEnable()
	{
		DropBrickVirtualButtonEventHandler.drop += createBrick;
		UserInputHandler.OnTap += mySelect;
	}

	private void OnDisable()
	{
		DropBrickVirtualButtonEventHandler.drop -= createBrick;
		UserInputHandler.OnTap -= mySelect;
	}

}
