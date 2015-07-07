using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour {
    /// <summary>
    /// xMove and yMove controll the direction of the movement, they will be normalized to be a vector of magnitude 1;
    /// </summary>
    [SerializeField][Range(-1.0f, 1.0f)]
    private float xMove;
    [SerializeField][Range(-1.0f,1.0f)]
    private float yMove;
    /// <summary>
    /// speed define the max speed of the movement;
    /// </summary>
    [SerializeField]
    float speed = 1;
    /// <summary>
    /// accel define how fast the object change speed
    /// </summary>
    [SerializeField]
    private float accel = 10;
    private Rigidbody2D ridgebd;
    private Vector2 dir;
    private Vector2 tempVel;
	// Use this for initialization
	void Start () {
        ridgebd = this.gameObject.GetComponent<Rigidbody2D>();
        dir = Vector2.zero;
        tempVel = Vector2.zero;

	}
    void FixedUpdate()
    {
        dir = new Vector2(xMove, yMove).normalized;
        tempVel = dir * accel;
        tempVel = Vector2.ClampMagnitude(tempVel, speed);
        this.ridgebd.velocity = tempVel;
    }
    public float XMove
    {
        set
        {
            xMove = value;
        }
    }
    public float YMove
    {
        set
        {
            yMove = value;
        }
    }
    public float Speed
    {
        set
        {
            speed = value;
        }
    }
}
