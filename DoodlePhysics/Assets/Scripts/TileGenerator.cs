using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile tile;
    public GameObject circle;

    private int counter = 0;
    private bool drawing = false;

    private int[,] values = new int[,] { { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1 },
                                         { 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1 },
                                         { 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1 },
                                         { 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1 },
                                         { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1 },
                                         { 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1 },
                                         { 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1 },
                                         { 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 1 } };

    Vector3Int origin = new Vector3Int(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Getting array: ");
        Debug.Log(cameraButtonHandler.binArray.GetValue(1, 1));
        Vector3Int tileIndex = new Vector3Int(0, 0, 0);
        for (int row = 0; row < cameraButtonHandler.binArray.GetLength(0); row++)
        {
            for (int column = 0; column < cameraButtonHandler.binArray.GetLength(1); column++)
            {
                if (cameraButtonHandler.binArray[row, column] == true)
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
        if (Input.GetMouseButtonUp(0))
        {
            drawing = false;
        }

        if (Input.GetMouseButtonDown(0) || drawing == true)
        {
            drawing = true;
            Vector3Int clickPosition = new Vector3Int((int)(Input.mousePosition.x/6.8), (int)(Input.mousePosition.y/6.6), 0);
            Debug.Log("Click" + counter + " " + clickPosition);
            tilemap.SetTile(clickPosition, tile);
            ++counter;
        }

        if(Input.GetMouseButtonDown(1))
        {
            tilemap.ClearAllTiles();
        }

        if(Input.GetMouseButtonDown(2))
        {
            Vector3Int clickPosition = new Vector3Int((int)(Input.mousePosition.x / 200), (int)(Input.mousePosition.y / 200), 0);
            Debug.Log("Circle Click " + clickPosition);
            Instantiate(circle, clickPosition, Quaternion.identity);
        }
    }
}
