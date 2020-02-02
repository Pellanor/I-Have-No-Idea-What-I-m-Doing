using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Smart Tile",
    menuName = "Tiles/Smart Tile")]
public class SmartTile : Tile
{
    public List<Sprite> sprites;
    private int index = 0;
    
    void Start() {
        index = 0;
    }

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData) {
        base.GetTileData(position, tilemap, ref tileData);

        tileData.sprite = sprites[index];
    }

    public void setTileIndex(int index) {
        if (index >= 0 && index < sprites.Count) {
            this.index = index;
        }
    }
}
