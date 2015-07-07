using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
public class MapLayer
{
    public IList<int> Data { get; set; }
    public string Name { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
}
public class MapLoader : MonoBehaviour {
    public static string groundLayer = "ground";
    public static string blockingLayer = "blocking";
    public TextAsset MapResource;
    private List<GameObject> tilePrefabs = new List<GameObject>();
    
    void Awake()
    {
        var jObj=DeserializeMap();
        LoadTilePrefabs();
        LayoutMap(jObj);
        
    }
    void LoadTilePrefabs(){
        int i=0;
        while (true)
        {
            i++;
            var tile=Resources.Load<GameObject>("tiles/tile" + i);
            if (tile != null)
            {
                //ensure size;
                if (i >= tilePrefabs.Count) tilePrefabs.AddRange(new GameObject[i-tilePrefabs.Count+1]);
                tilePrefabs[i] = tile;
                
            }
            else
            {
                break;
            }
            
        }
    }
    public static void index2Coor(MapLayer layer, int index, out int x, out int y){
        int row = index / layer.Width;//row is from 0 to 15
        int col = index % layer.Width;//col is from 0 to 15
        x=col;
        y=layer.Height-row-1;

    }
    IList<MapLayer> DeserializeMap()
    {
        Debug.Log("start deserializing map");
        string st = string.Format(@"{0}", MapResource.text);
        JObject obj = JObject.Parse(st);
        IList <MapLayer> layers= new List<MapLayer>();
        foreach (JToken token in obj["layers"].Children()){
            MapLayer layer = new MapLayer();
            layer.Name = (string)token["name"];
            layer.Data=JsonConvert.DeserializeObject<List<int>>(token["data"].ToString());
            layer.Height = (int)token["height"];
            layer.Width = (int)token["width"];
            layers.Add(layer);
        }
        this.transform.position = new Vector3(-layers[0].Width / 2,-layers[0].Height / 2,this.transform.localPosition.z);
        return layers;

    }
    void LayoutMap(IList<MapLayer> jMap)
    {
        string layerName="blocking";
        foreach (MapLayer layer in jMap)
        {
            
            if (layer.Name.Equals("ground")) layerName = groundLayer;
            else layerName = blockingLayer;

            for (int i = 0; i < layer.Data.Count; i++)
            {
                if (layer.Data[i] == 0) continue;
                GameObject obj=(GameObject)Instantiate(tilePrefabs[layer.Data[i]], Vector3.zero, Quaternion.identity);
                obj.layer = LayerMask.NameToLayer(layerName);
                int x;
                int y;
                index2Coor(layer, i, out x, out y);
                obj.transform.parent = this.transform;
                obj.transform.localPosition = new Vector3(x, y, y);
                
            }
        }
        
    }
	
}
