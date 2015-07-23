using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Speed))]
[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour {
    
    private Rigidbody2D ridgebd;
    
    private Speed speed;
    
	// Use this for initialization
	void Start () {
        ridgebd = this.gameObject.GetComponent<Rigidbody2D>();
        this.speed = this.gameObject.GetComponent<Speed>();
        
	}

    void FixedUpdate()
    {
       
       
        this.ridgebd.velocity = speed.currentVel;
    }
    
}