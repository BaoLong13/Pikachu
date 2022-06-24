using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private Tile tile;
    [SerializeField] private Camera cam;

    private Dictionary<Vector2, Tile> tiles;


    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                var spawnedTile = Instantiate(tile, new Vector3(i, j), Quaternion.identity);
                spawnedTile.name = $"Tile {i} {j}";

                var isOffSet = (i + j) % 2 == 1;
                spawnedTile.Init(isOffSet);

                tiles[new Vector2(i, j)] = spawnedTile;
            }
        }
        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10) ;
    }

    public Tile GetTileAtPosition (Vector2 pos)
    {
        if (tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }
        return null;
    }
}
