using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Util {
    public static List<T> getComponentsWithTag<T>(GameObject gameObject, string tag)
    {

        if (!typeof(TagComponent).IsAssignableFrom(typeof(T)))
        {
            Debug.Log(typeof(T).Name+" is not a TagComponent, cannot use getComponentsWithTag method" );
            return new List<T>();
        }
        IList comlist = gameObject.GetComponents<T>();
        List<T> tempList=new List<T>();
        foreach (T component in comlist)
        {
            if ((component as TagComponent).TAG.Equals(tag))
            {
                tempList.Add(component);
            } 
        }
        return tempList;
        
    }
    public static T getComponentWithTag<T>(GameObject gameObject,string tag){
        List<T> list = getComponentsWithTag<T>(gameObject, tag);
        if (list.Count>=1 && list[0] != null) return list[0];
        else return default(T);
        
    }
    /// <summary>
    /// move the the object to the destination with the custom pivot
    /// </summary>
    /// <param name="pivot"></param>
    /// <param name="dest"></param>
    /// <returns></returns>

    public static void movePivotLocal(GameObject obj, Vector3 pivot, Vector3 dest)
    {
        obj.transform.localPosition = dest - pivot;
    }
	
}
