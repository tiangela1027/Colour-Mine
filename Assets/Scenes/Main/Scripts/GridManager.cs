using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private float tileSize = 1;

    public GameObject squarePrefab;
    public static int gridWidth = 10;
    public static int gridHeight = 20;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    private void GenerateGrid()
    {
        for (int row = 0; row < gridWidth; row++)
        {
            for (int col = 0; col < gridHeight; col++)
            {
                GameObject tile = (GameObject)Instantiate(squarePrefab, transform);
                tile.name = "Square[" + row + "," + col + "]";

                float posX = col * tileSize;
                float posY = row * -tileSize;

                tile.transform.position = new Vector2(posX, posY);
            }
        }
    }
}
