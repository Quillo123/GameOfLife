using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class CheckCells : MonoBehaviour
{

    #region Properties
    public Tilemap tilemap;
    public Cells cells;
    public Pause pause;
    private uint waitTime = 25;
    private uint waitCount = 0;
    private float speed = 75;
    public Slider slider;
    #endregion
    // Start is called before the first frame update
    void Start()
    {

    }

    void ChangeSpeed(uint speed)
    {
        if(speed > 100 || speed < 0)
        {
            Debug.LogError("Invalid Speed");
            speed = 0;
        }
        else
            waitTime = (uint)-(speed - 100);
        waitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(slider.value != speed)
        {
            ChangeSpeed((uint)slider.value);
            speed = slider.value;
        }
            

        if (!pause.paused)
        {
            if (waitCount == waitTime)
            {
                bool[,] nextGen = NextGeneration();
                for (int i = -cells.size; i <= cells.size; i++)
                {
                    for (int j = -cells.size; j <= cells.size; j++)
                    {
                        int count = AdjacentLivingCells(new Vector3Int(i, j, 0), tilemap);
                        Vector3Int Location = new Vector3Int(i, j, 0);
                        Cell tile = (Cell)tilemap.GetTile(Location);
                        if (tile != null)
                        {
                            tile.alive = nextGen[i + 50, j + 50];
                        }
                    }
                }
                waitCount = 0;
            }
            else
                waitCount++;
            
        }
            
    }

    bool[,] NextGeneration()
    {
            bool[,] ret = new bool[(cells.size * 2) + 1, (cells.size * 2) + 1];
            for (int i = -cells.size; i <= cells.size; i++)
            {
                for (int j = -cells.size; j <= cells.size; j++)
                {
                int count = AdjacentLivingCells(new Vector3Int(i, j, 0), tilemap);
                Vector3Int Location = new Vector3Int(i, j, 0);
                Cell tile = (Cell)tilemap.GetTile(Location);
                ret[i + 50, j + 50] = tile.alive;
                if (tile != null)
                    {
                    if (count < 2 || count > 3)
                        {
                            ret[i + 50, j + 50] = false;
                        }
                        else if (count == 3)
                        {
                            ret[i + 50, j + 50] = true;
                        }
                    }
                }
            }
        return ret;
    }

    public int AdjacentLivingCells(Vector3Int location, Tilemap tileMap)
    {
        int cellCount = 0;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (!(i == 0 && j == 0))
                {
                    Vector3Int searchLocation = location;
                    searchLocation.x += i;
                    searchLocation.y += j;
                    Cell tile = (Cell)tileMap.GetTile(searchLocation);
                    if (tile != null)
                    {
                        if (tile.alive)
                            cellCount++;
                    }
                }
            }
        }
        return cellCount;
    }
}
