using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MovementController))]
public class DummyInputController : MonoBehaviour {
    private MovementController movement;
    void Start()
    {
        movement = GetComponent<MovementController>();

    }
   
	// Update is called once per frame
	void Update () {
        movement.XMove = -1;
        movement.YMove = 0;
	}
}
