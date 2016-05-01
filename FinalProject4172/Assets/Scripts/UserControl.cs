﻿using UnityEngine;
using System.Collections;

public class UserControl : MonoBehaviour {

	public GameObject head;
	public GameObject board;

	public GameObject boardTarget;

	float fixedDistance = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 targetPosition = gameObject.transform.position;
		Vector3 headPosition = head.transform.position;
		Vector3 boardPosition = board.transform.position;
		Vector3 boardTargetPosition = boardTarget.transform.position;
		Vector3 fixedVector = boardTargetPosition - headPosition;


		//Translation
		fixedDistance = Mathf.Abs(boardTargetPosition.y - headPosition.y);

		float z = Mathf.Abs(targetPosition.z - headPosition.z);

		float displacement = z - fixedDistance;
		//Debug.Log (displacement);
		Vector3 move = new Vector3 (boardPosition.x, boardPosition.y, displacement);
		board.transform.position = move;

		//Rotation

		Quaternion q = gameObject.transform.rotation;
		board.transform.rotation = q;
	
	}
}
