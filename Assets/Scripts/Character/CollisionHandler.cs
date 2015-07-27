using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Speed))]
public class CollisionHandler : MonoBehaviour {
    Speed speed;
    [SerializeField]
    private float margin = 0.2f;
    int horizontalRays = 8;
    int verticalRays = 8;

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
        Vector2 horizontalHalf=new Vector2(bounds.extents.x * (1 - margin), 0);
        Vector2 verticalHalf=new Vector2(0,bounds.extents.y * (1 - margin));
        //Vector2 left = center - horizontalHalf;
       // Vector2 right=center+
        speed.Delta = speed.currentVel * deltaTime;
        float y = speed.Delta.y;
        float x = speed.Delta.x;
        RaycastHit2D hitX, hitY;
        for (int i = 0; i < verticalRays; i++)
        {
            float lerpAmount = (float)i / (float)(verticalRays - 1);
            Vector2 origin = Vector2.Lerp(center - horizontalHalf, center + horizontalHalf, lerpAmount);
            
            if (y > 0)
            {

                hitY = Raycast(origin, Vector2.up, extents.y + y);

            }
            else
            {

                hitY = Raycast(origin, Vector2.down, extents.y - y);

            }
            if (hitY.collider != null)
            {
                //TODO change this so that y is equal to the closest
                y = extents.y - hitY.distance;
            }
        }
        for (int i = 0; i < horizontalRays; i++)
        {
            float lerpAmount = (float)i / (float)(verticalRays - 1);
            Vector2 origin = Vector2.Lerp(center - verticalHalf, center + verticalHalf, lerpAmount);
            if (x > 0)
            {

                hitX = Raycast(origin, Vector2.right, extents.x + x);

            }
            else
            {
                hitX = Raycast(origin, Vector2.left, extents.x - x);

            }
            if (hitX.collider != null)
            {
                //TODO change this so that y is equal to the closest
                x = extents.x - hitX.distance;
            }
        
        }
        
      
        
        return new Vector2(x,y);

    }

}
