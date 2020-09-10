using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Cells : MonoBehaviour
{
    #region Properties
    public Sprite DeadCell;
    public Sprite AliveCell;
    public Tilemap cellTiles;
    public int size;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        CreateCells();
    }

    public void CreateCells()
    {
        Debug.Log("Creating Cells");
        for (int i = -size; i <= size; i++)
        {
            for (int j = -size; j <= size; j++)
            {
                int rand = Random.Range(0, 10);
                Cell cell = ScriptableObject.CreateInstance<Cell>();
                cell.AliveCell = AliveCell;
                cell.DeadCell = DeadCell;
                cellTiles.SetTile(new Vector3Int(i, j, 0), cell);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
