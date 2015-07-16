﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MovementController))]
public class KeyboardController :MonoBehaviour {
    public string horizontalInput = "Horizontal";
    public string verticalInput = "Vertical";
    private MovementController movement;
    void Start()
    {
        movement = GetComponent<MovementController>();

    }
   
	
	// Update is called once per frame
	void Update () {
        movement.XMove = Input.GetAxisRaw(horizontalInput);
        movement.YMove = Input.GetAxisRaw(verticalInput);
	}
}
