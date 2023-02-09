using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileRow
{
    public TileRow(int i)
    {
        data = new List<TileComponent>(i);
        for (int x = 0; x < i; x++)
        {
            data.Add(null);
        }
    }
    public List<TileComponent> data = new List<TileComponent>();
}

public class TileLevelGenerator : MonoBehaviour
{
    [SerializeField] Vector2Int size;
    [SerializeField] List<TileRow> map = new List<TileRow>();
    [SerializeField] GameObject floorPrefab;
    [SerializeField] float spacing = 0.01f;


    public static TileLevelGenerator instance;

    public TileComponent FindTile(Vector3 p)
    {
        p -= transform.position;
        p -= floorPrefab.transform.lossyScale*0.5f;
        print(p);

        return map[(int)p.x].data[(int)p.y];
    }

    private void Awake()
    {
        if (instance)
            DestroyImmediate(gameObject);

        instance = this;


        //map = new List<TileRow>();

        if (transform.childCount != size.x * size.y)
            throw new System.Exception("Update mapSize");
    }

    [ContextMenu("CreateMap")]
    void CreateMap()
    {
        for (int i = transform.childCount; i > 0; i--)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
        map = new List<TileRow>();


        for (int x = 0; x < size.x; x++)
        {
            TileRow tr = new TileRow(size.y);
            
            for (int y = 0; y < size.y; y++)
            {
                GameObject ob = Instantiate(floorPrefab, transform);
                ob.transform.position = transform.position + new Vector3(x + x * spacing, y + y * spacing);

                tr.data[y] = ob.GetComponent<TileComponent>();
            }
            map.Add(tr);
        }
    }
}