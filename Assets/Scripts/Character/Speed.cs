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
    public Vector2 Delta = Vector2.zero;
    public Vector2 currentVel;
    
    private IList boosts;
    [SerializeField]
    private CollisionHandler colHandler;
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
            Delta=colHandler.Test(Time.deltaTime);
            
           
        }
        else
        {
            Delta = currentVel * Time.deltaTime;
        }
        transform.Translate(Delta);
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
