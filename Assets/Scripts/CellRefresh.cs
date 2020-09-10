using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class CellRefresh : MonoBehaviour
{

    public Tilemap tileMap;

    // Start is called before the first frame update
    void Start()
    {
        //tileMap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {

        if (tileMap != null)
        {
            tileMap.RefreshAllTiles();
        }


    }

}
