using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Speed))]
public class KeyboardController :MonoBehaviour {
    public string horizontalInput = "Horizontal";
    public string verticalInput = "Vertical";
    private Speed speed;
    void Start()
    {
        speed = GetComponent<Speed>();

    }
	// Update is called once per frame
	void Update () {
        speed.XMove = Input.GetAxisRaw(horizontalInput);
        speed.YMove = Input.GetAxisRaw(verticalInput);
	}
}
