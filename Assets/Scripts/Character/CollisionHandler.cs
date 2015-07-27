using UnityEngine;
using System.Collections;
using System;

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

	
	

    RaycastHit2D Raycast(Vector2 start, Vector2 dir, float distance)
    {

        RaycastHit2D hit=Physics2D.Raycast(start, dir, distance,(1<<LayerMask.NameToLayer("blocking")));
        if (hit.collider != null)
        {
           
        }
        Debug.DrawLine(start, start + (dir * distance), Color.red);
        return hit;
    }
   
    //draw the ray and test
    public Vector2 Test(float deltaTime)
    {
        //Rect box=new Rect()
        
        Bounds bounds = GetComponent<Collider2D>().bounds;
        Vector2 center = bounds.center;
        Vector2 extents = bounds.extents;
        speed.Delta = speed.currentVel * deltaTime;
        float y = speed.Delta.y;
        float x = speed.Delta.x;
        RaycastHit2D hitX, hitY;
        if (y > 0)
        {
            
            hitY=Raycast(center, Vector2.up, extents.y+y);
            
        }
        else
        {
            
            hitY=Raycast(center, Vector2.down,extents.y-y);
           
        }
        if (x > 0)
        {
            
            hitX=Raycast(center, Vector2.right, extents.x+x);
            
        }
        else
        {
            hitX=Raycast(center, Vector2.left, extents.x-x);
            
        }
        
        int mask = LayerMask.NameToLayer("blocking");
        if (hitX.collider != null)
        {

            x = extents.x - hitX.distance;
        }
        if (hitY.collider!=null){

            y = extents.y - hitY.distance;
        }
        
        return new Vector2(x,y);

    }

}
