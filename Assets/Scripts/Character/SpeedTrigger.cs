using UnityEngine;
using System.Collections;

public class SpeedTrigger : TagComponent
{
    [SerializeField]
    private float boostAmount = 1.5f;
    

    void Awake()
    {
        this.TAG = "speedTrigger";

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        var boost = Util.getComponentWithTag<SpeedBoost>(collider.gameObject,this.TAG);
        if (boost == null)
        {
            boost=collider.gameObject.AddComponent<SpeedBoost>();
        }
        boost.Boost = boostAmount;
        boost.TAG = this.TAG;
        boost.BoostCount++;
        
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        
        var boost = Util.getComponentWithTag<SpeedBoost>(collider.gameObject, this.TAG);
        if (boost != null)
        {
            boost.BoostCount--;
            
            if (boost.BoostCount <= 0)
            {
                Destroy(boost);
            }

        }
    }
   
}
