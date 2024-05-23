using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : UIScript
{
    public Tilemap[] tilemaps;

    public void ActivateTilemap(Tilemap newTilemap)
    {
        foreach (Tilemap tilemap in tilemaps)
        {
            tilemap.gameObject.SetActive(false);
        }
        newTilemap.gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (tilemaps.Length > 0)
        {
            ActivateTilemap(tilemaps[0]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
