using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Speed))]
public class CollisionHandler : MonoBehaviour {
    Speed speed;
    [SerializeField]
    private float margin = 0.1f;
    int horizontalRays = 4;
    int verticalRays = 4;

    void Awake()
    {
        this.speed = gameObject.GetComponent<Speed>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //draw the ray and test
    void FixedUpdate()
    {
        //Rect box=new Rect()
        bool hit = Physics2D.Raycast(transform.position, Vector2.up);
        Debug.DrawRay(transform.position, Vector2.up);
        int mask = LayerMask.NameToLayer("block");
        if (hit)
        {
            Debug.Log("I hit something");
        }
    }

}
