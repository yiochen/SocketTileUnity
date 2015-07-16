using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
    public List<GameObject> Prefabs;
    //default spawn interval 10s
    public int SpawnInterval = 10;
    private bool spawning = false;
    
    public bool Spawning
    {
        get
        {
            return spawning;
        }
        set
        {
            if (spawning && !value)
            {
                spawning = false;
            }
            else if (!spawning && value)
            {
                spawning = true;
                StartCoroutine(Spawn());
            }

        }
    }
    public void Start()
    {
        this.Spawning = true;
    }
    protected virtual IEnumerator Spawn()
    {
        while (Spawning)
        {
            var obj=Instantiate(Prefabs[Random.Range(0, (Prefabs.Count - 1))]);
            InitObject(obj);
            yield return new WaitForSeconds(SpawnInterval);
        }
    }
    protected virtual void InitObject(GameObject obj){}
}
