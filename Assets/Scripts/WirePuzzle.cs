using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WirePuzzle : MonoBehaviour
{
    public Grid grid;
    public Tilemap ActionTiles;
    public Tilemap WireTiles;
    public int steps;
    public PopupConversation popup;
    public List<string> dialog;
    public VictoryCondition victoryCondition;
    private int tileIndex = 0;

    void Start() {
        tileIndex = 0;
        //Debug.Log(dialog[tileIndex]);
        UpdateTiles();
    }

    private void OnMouseDown() {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        TileBase clickedTile = ActionTiles.GetTile(grid.WorldToCell(mouseWorldPos));
        if (clickedTile != null) {
            tileIndex++;
            if (tileIndex+1 >= steps) {
                victoryCondition.DoVictory();
            }
           // Debug.Log(dialog[tileIndex]);
            UpdateTiles();
        }
    }

    private void UpdateTiles() {
        ShowDialog();
        UpdateTileMap(ActionTiles);
        UpdateTileMap(WireTiles);
    }

    private void ShowDialog() {
        if (tileIndex < dialog.Count -1) {
            string key = dialog[tileIndex];
            if (key != "") {
                popup.LoadConversation(key);
            }
        }
    }

    private void UpdateTileMap(Tilemap map) {
        TileBase[] tiles = map.GetTilesBlock(map.cellBounds);
        foreach (TileBase tile in tiles) {
            if (tile == null) {
                continue;
            }
            //Debug.Log("Tile " + tile);
            if (typeof(SmartTile).IsAssignableFrom(tile.GetType())) {
                //Debug.Log("is a Smart Tile with index " + tileIndex);
                ((SmartTile)tile).setTileIndex(tileIndex);
            } else if (typeof(WireTile).IsAssignableFrom(tile.GetType())) {
                //Debug.Log("is a Wire Tile with index " + tileIndex);
                ((WireTile)tile).setTileIndex(tileIndex);
            }
        }
        map.RefreshAllTiles();
    }
}
