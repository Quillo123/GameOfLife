using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu]
public class Cell : TileBase
{

    #region Properties
    public bool alive = false;

    public Sprite AliveCell;
    public Sprite DeadCell;

    private Sprite newSprite;

    #endregion

    public override void GetTileData(Vector3Int location, ITilemap tileMap, ref TileData tileData)
    {
        base.GetTileData(location, tileMap, ref tileData);

        if (alive)
            newSprite = AliveCell;
        else
            newSprite = DeadCell;  

        //    Change Sprite
        tileData.sprite = newSprite;
    }


#if UNITY_EDITOR
    // The following is a helper that adds a menu item to create a RoadTile Asset
    [MenuItem("Assets/Create/Cell")]
    public static void CreateCell()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Cell", "New Cell", "Asset", "Save Cell", "Assets");
        if (path == "")
            return;
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<Cell>(), path);
    }
#endif
}
