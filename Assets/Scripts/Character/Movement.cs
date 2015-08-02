using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Speed))]
public class Movement : MonoBehaviour,Collidable {
    private Speed speed;
    public void OnCollide(Vector3 distance)
    {
        this.transform.Translate(distance);
    }
    public void OnCanMove(Vector3 distance)
    {
        this.transform.Translate(distance);
    }

	void Awake () {
        this.speed = GetComponent<Speed>();
        speed.OnCollideHandler += OnCollide;
        speed.OnCanMoveHandler += OnCanMove;
	}
	
	
}
