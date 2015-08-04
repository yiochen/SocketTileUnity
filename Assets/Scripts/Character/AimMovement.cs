using UnityEngine;
using System.Collections;
/// <summary>
/// Movement handler that needs to find a target first, then move toward the target in uniform speed.
/// </summary>
[RequireComponent(typeof(CollisionHandler))]
public class AimMovement : MonoBehaviour {

    CollisionHandler colHandler;
    float speed;
    bool isMoving = false;
	// Use this for initialization
	void Start () {
        this.colHandler = GetComponent<CollisionHandler>();
        this.speed = 0.1f;
	}

    GameObject findTarget(int mask, Vector2 dir, float maxDistance)
    {
        Vector2 canMove;
        if (!colHandler.Test(dir.normalized * maxDistance, out canMove, mask))
        {
            return null;
        }
        return null;
    }
	// Update is called once per frame
	void Update () {
	    
	}
    void startMoving(Vector2 dir)
    {
        if (isMoving) return;

        //find the target distance 
        //move in constant distance in every update
    }
    void FixedUpdate()
    {

    }
    IEnumerator Move(Vector2 distance)
    {
        Vector2 dir = distance.normalized;
        while (distance.magnitude >= speed)
        {
            gameObject.transform.Translate(dir*speed);
            distance -= speed*dir;
            yield return null;
        }
    }
    
}
