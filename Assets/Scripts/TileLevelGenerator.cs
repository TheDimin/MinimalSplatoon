using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLevelGenerator : MonoBehaviour
{
    [SerializeField] Vector2Int size;
    [SerializeField] GameObject floorPrefab;
    [SerializeField] List<TileComponent> tiles = new List<TileComponent>();


    public static TileLevelGenerator instance;

    public TileComponent FindTile(Vector3 p)
    {
        p.z = transform.position.z;
        foreach (TileComponent tile in tiles)
        {
            if (tile.Collider2D.bounds.Contains(p))
                return tile;
        }

        return null;
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


#if UNITY_EDITOR
    [ContextMenu("CreateMap")]
    void CreateMap()
    {
        for (int i = transform.childCount; i > 0; i--)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
        tiles = new List<TileComponent>(size.x * size.y);


        for (int x = 0; x < size.x; x++)
            for (int y = 0; y < size.y; y++)
            {

                GameObject ob = UnityEditor.PrefabUtility.InstantiatePrefab(floorPrefab, transform) as GameObject;
                ob.transform.position = transform.position + new Vector3(x, y);

                tiles.Add(ob.GetComponent<TileComponent>());
            }
    }
#endif
}