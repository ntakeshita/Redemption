﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Vector3 moveDirection = Vector3.zero;
	CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);
		controller.Move(moveDirection * 10);
	}
}
