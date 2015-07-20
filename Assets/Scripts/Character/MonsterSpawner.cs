using UnityEngine;
using System.Collections;

public class MonsterSpawner : Spawner {

    protected override void InitObject(GameObject obj)
    {
        base.InitObject(obj);
        obj.transform.parent = MapLoader.getMap().transform;
        obj.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
        obj.layer = LayerMask.NameToLayer(MapLoader.blockingLayer);
    }
}
