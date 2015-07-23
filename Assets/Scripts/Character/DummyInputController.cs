using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Speed))]
public class DummyInputController : MonoBehaviour {
    private Speed speed;
    void Start()
    {
        speed = GetComponent<Speed>();

    }
    // Update is called once per frame
    void Update()
    {
        speed.XMove = -1;
        speed.YMove = 0;
    }
}
