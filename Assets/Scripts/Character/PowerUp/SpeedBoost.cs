using UnityEngine;
using System.Collections;

public class SpeedBoost : TagComponent {
    private int boostCount;

    public int BoostCount
    {
        get
        {
            return boostCount;
        }
        set
        {
            if (value <= 0)
            {
                Destroy(this);
                return;
            }
            this.boostCount = value;
        }
    }
    [Range(0f, 5f)]
    public float Boost = 1f;
    
}
