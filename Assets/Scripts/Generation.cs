using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    /// <summary>
    /// //
    /// </summary>
    private int[,] intMap;
    [SerializeField] private Vector2Int mapSize;
    [SerializeField] private int mines;
    [SerializeField] private GameObject cell;
    [SerializeField] private float spacing;

    
    private void Start()
    {
        intMap=new int[mapSize.x,mapSize.y];
        GenerateMines();
        GenerateNums();
        GenerateRealMap();
    }
    private void GenerateRealMap()
    {
        for (int i = 0; i < mapSize.x; i++)
        {
            for (int j = 0; j < mapSize.y; j++)
            {
                Instantiate(cell, new Vector3(i,0 ,j) * spacing, Quaternion.identity, transform).GetComponent<Cell>().SetNum(intMap[i, j]);
            }
        }
    }
    private void GenerateNums()
    {
        for (int i = 0; i < mapSize.x; i++)
        {
            for (int j = 0; j < mapSize.y; j++)
            {
                if (intMap[i,j]<0)
                {
                    Vector2Int bombCell = new Vector2Int(i,j);
                    TryToSetCellValueNearly(bombCell, new Vector2Int(1, 1));
                    TryToSetCellValueNearly(bombCell, new Vector2Int(0, 1));
                    TryToSetCellValueNearly(bombCell, new Vector2Int(-1, 1));
                    TryToSetCellValueNearly(bombCell, new Vector2Int(-1, 0));
                    TryToSetCellValueNearly(bombCell, new Vector2Int(-1, -1));
                    TryToSetCellValueNearly(bombCell, new Vector2Int(0, -1));
                    TryToSetCellValueNearly(bombCell, new Vector2Int(1, -1));
                    TryToSetCellValueNearly(bombCell, new Vector2Int(1, 0));

                }
            }
        }
    }

    private void TryToSetCellValueNearly(Vector2Int origin, Vector2Int offset)
    {
        bool isSpaceOffSetX = origin.x + offset.x <= intMap.GetLength(0) - 1 && origin.x + offset.x >= 0;
        bool isSpaceoffSetY = origin.y +offset.y <= intMap.GetLength(1) - 1 && origin.y +offset.y >= 0;

        if (isSpaceOffSetX && isSpaceoffSetY)
        {
            intMap[origin.x + offset.x, origin.y + offset.y]++;
        }
    }
    private void GenerateMines()
    {
        int spawned = 0;
        while (spawned < mines)
        {
            for (int i = 0; i < mapSize.x; i++)
            {
                for(int j = 0; j < mapSize.y; j++)
                {
                    if(Random.Range(0, mapSize.x*mapSize.y) == 0 && CurrentCountMines()< mines)
                    {
                        intMap[i, j] = -999;
                        spawned++;
                    }
                }
            }
        }
    }
    private int CurrentCountMines()
    {
        int mines = 0;

        for (int i = 0; i < mapSize.x; i++)
        {
            for (int j = 0; j < mapSize.y; j++)
            {
                if (intMap[i,j]<0)
                {
                    mines++;
                }
            }
        }
        return mines;
    }
    
}
