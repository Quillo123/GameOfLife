using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class InputController : MonoBehaviour
{
    #region Properties
    public TilemapCollider2D collider;
    public Tilemap tilemap;
    public Cells cells;
    public Pause pause;

    #endregion

    private void Update()
    {
        Pause();
        SelectCell();
        Clear();
    }
    void SelectCell()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var touchPos = new Vector2(wp.x, wp.y);

            Vector2 tilePos = collider.ClosestPoint(touchPos);

            
            Cell tile = (Cell)tilemap.GetTile(new Vector3Int((int)tilePos.x, (int)tilePos.y, 0));
            tile.alive = !tile.alive;
        }
    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pause.paused = !pause.paused;
        }
    }

    void Clear()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            cells.CreateCells();
        }
    }
}
