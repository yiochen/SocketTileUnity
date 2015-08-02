using UnityEngine;
using System.Collections;

public class Speed : MonoBehaviour {
    /// <summary>
    /// xMove and yMove controll the direction of the movement, they will be normalized to be a vector of magnitude 1;
    /// </summary>
    [SerializeField]
    [Range(-1.0f, 1.0f)]
    private float xMove;
    [SerializeField]
    [Range(-1.0f, 1.0f)]
    private float yMove;
    /// <summary>
    /// accel define how fast the object change speed
    /// </summary>
    [SerializeField]
    private float accel = 10;
    public float baseSp = 2;
    public float sp = 2;
    private Vector2 dir;
    public Vector2 currentVel;
    
    private IList boosts;
    [SerializeField]
    private CollisionHandler colHandler;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="distance">how far the object can move in one direction before colliding into another object</param>
    public delegate void OnCollide(Vector3 distance);
    /// <summary>
    /// according to the current speed, the object can move this much distance in the next update without collision
    /// </summary>
    /// <param name="distance">distance and direction of movement in the next update</param>
    public delegate void OnCanMove(Vector3 distance);
    public OnCollide OnCollideHandler;
    public OnCanMove OnCanMoveHandler;
    void Start()
    {
        
        dir = Vector2.zero;
        currentVel = Vector2.zero;
        
    }
    void Update()
    {
        boosts = this.gameObject.GetComponents<SpeedBoost>();
    }
    void FixedUpdate()
    {
        var boostedSpeed = baseSp;
        if (boosts != null)
        {
            foreach (SpeedBoost boost in boosts)
            {
                boostedSpeed *= boost.Boost;
            }
        }
        this.sp = boostedSpeed;
        dir = new Vector2(xMove, yMove).normalized;
        currentVel = dir * accel;
        currentVel = Vector2.ClampMagnitude(currentVel, sp);
        if (colHandler != null)
        {
            Vector2 distance;
            if (colHandler.Test(currentVel * Time.deltaTime, out distance))
            {
                //collided
                if (OnCollideHandler != null) OnCollideHandler(distance);
            }
            else
            {
                if (OnCanMoveHandler != null) OnCanMoveHandler(distance);
            }
        }
        else
        {
            if (OnCanMoveHandler != null) OnCanMoveHandler(currentVel * Time.deltaTime);
        }
        
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
}
