using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Wire Tile",
    menuName = "Tiles/Wire Tile")]
public class WireTile : Tile
{

    public List<Tile> tiles;
    private int index = 0;

    void Start() {
        index = 0;
    }

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData) {
        base.GetTileData(position, tilemap, ref tileData);
        tileData.color = tiles[index].color;
        tileData.sprite = tiles[index].sprite;
    }

    public void setTileIndex(int index) {
        if (index >= 0 && index < tiles.Count) {
            this.index = index;
        }
    }
}
