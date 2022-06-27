using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private Tile tile;
    [SerializeField] private Camera cam;

    public static GridManager instance;

    private Dictionary<Vector2, Tile> tiles;

    private void Awake()
    {
        instance = this;
        tiles = new Dictionary<Vector2, Tile>();
    }

    public void GenerateGrid()
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
        // Center Camera
        cam.transform.position = new Vector3((float)width/2 - 0.5f, (float)height/2 - 0.5f, -10);
        GameManager.instance.ChangeState(GameState.SpawnBall);
    }

    public Tile GetTileAtPosition (Vector2 pos)
    {
        if (tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }
        return null;
    }

    public Tile GetSpawnedTile()
    {
        return tiles.Where(t => t.Value.Walkable).OrderBy(t => Random.value).First().Value;
    }
}
