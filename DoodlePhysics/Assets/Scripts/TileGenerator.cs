using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile tile;

    private int[,] values = new int[,] { { 1, 1, 1, 1, 1},
                                         { 0, 1, 0, 0, 1 },
                                         { 0, 0, 0, 0, 1 },
                                         { 1, 1, 1, 1, 1 } };

    Vector3Int origin = new Vector3Int(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        Vector3Int tileIndex = new Vector3Int(0, 0, 0);
        for (int row = 0; row < values.GetLength(0); row++)
        {
            for (int column = 0; column < values.GetLength(1); column++)
            {
                if (values[row, column] == 1)
                {
                    tilemap.SetTile(tileIndex, tile);
                }
                tileIndex.Set(tileIndex.x + 1, tileIndex.y, tileIndex.z);
            }
            tileIndex.Set(0, tileIndex.y + 1, tileIndex.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
