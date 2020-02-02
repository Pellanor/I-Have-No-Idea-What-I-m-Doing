using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class WirePuzzle : MonoBehaviour
{
    public Grid grid;
    public Tilemap tilemap;
    public int steps;
    public List<string> dialog;
    public VictoryCondition victoryCondition;
    private int tileIndex = 0;

    void Start() {
        tileIndex = 0;
        Debug.Log(dialog[tileIndex]);
        UpdateTiles();
    }

    private void OnMouseDown() {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        TileBase clickedTile = tilemap.GetTile(grid.WorldToCell(mouseWorldPos));
        if (clickedTile != null) {
            tileIndex++;
            if (tileIndex+1 >= steps) {
                victoryCondition.DoVictory();
            }
            Debug.Log(dialog[tileIndex]);
            UpdateTiles();
        }
    }

    private void UpdateTiles() {
        TileBase[] tiles = tilemap.GetTilesBlock(tilemap.cellBounds);
        foreach (TileBase tile in tiles) {
            if (tile == null) {
                continue;
            }
            //Debug.Log("Tile " + tile);
            if (typeof(SmartTile).IsAssignableFrom(tile.GetType())) {
                //Debug.Log("is a Smart Tile with index " + tileIndex);
                ((SmartTile)tile).setTileIndex(tileIndex);
            }
        }
        tilemap.RefreshAllTiles();
    }
}
