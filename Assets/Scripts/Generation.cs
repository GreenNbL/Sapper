using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    private Cell[,] cellMap;
    [SerializeField] private int[,] intMap;
    [SerializeField] private GameObject wall;
    private Animator sceneApper;
    [SerializeField] private Vector2Int mapSize;
    private int mines;
    [SerializeField] private GameObject cell;
    [SerializeField] private float spacing;
   

    public Vector2Int getMapSize()
    {
        return mapSize;
    }
    private void FillMapSize()
    {
        mapSize.x = MapSize.x;
        mapSize.y = MapSize.y;
        mines = MapSize.amountMines;
        Debug.Log(mines);


    }
    private void Start()
    {
        FillMapSize();
        intMap = new int[mapSize.x, mapSize.y];
        cellMap = new Cell[mapSize.x, mapSize.y];
        GenerateMines();
        GenerateNums();
        GenerateRealMap();
        GenerateWalls();
    }
    private void GenerateWalls()
    {
        int y_start = -1;
        int x_start = -1;
        int  width= 25;
        for (int i =-1; i < mapSize.x+1; i++)
        {
            for ( int k=0;k< width; k++)
            { 
                Instantiate(wall, new Vector3(i, 0, x_start-k) * spacing, Quaternion.identity, transform);
                Instantiate(wall, new Vector3(i, 0, x_start + mapSize.x + 1 + k) * spacing, Quaternion.identity, transform);
            }
        }
        for (int j = -1; j < mapSize.y + 1+ width*2; j++)
        {
            for (int k = 0; k < width; k++)
            {
                Instantiate(wall, new Vector3(y_start-k, 0, j-width) * spacing, Quaternion.identity, transform);
                Instantiate(wall, new Vector3(y_start+k + mapSize.y + 1, 0, j-width) * spacing, Quaternion.identity, transform);
            }
        }
        for (int i = -1; i < mapSize.x+1; i++)
        {
            for (int j = -1; j < mapSize.y+1; j++)
            {
                Instantiate(wall, new Vector3(i, -1, j) * spacing, Quaternion.identity, transform); 
            }
        }
    }
    private void GenerateRealMap()
    {
        for (int i = 0; i < mapSize.x; i++)
        {
            for (int j = 0; j < mapSize.y; j++)
            {
                Cell c = Instantiate(cell, new Vector3(i, 0, j) * spacing, Quaternion.identity, transform).GetComponent<Cell>();
                c.SetNum(intMap[i, j]);
                c.Gen(this, new Vector2Int(i, j));
                cellMap[i, j] = c;
            }
        }
    }
    public void OpenEmpty(Vector2Int genPosotion)
    {
        TryToOpenCellValueNearly(genPosotion, new Vector2Int(1, 1));
        TryToOpenCellValueNearly(genPosotion, new Vector2Int(0, 1));
        TryToOpenCellValueNearly(genPosotion, new Vector2Int(-1, 1));
        TryToOpenCellValueNearly(genPosotion, new Vector2Int(-1, 0));
        TryToOpenCellValueNearly(genPosotion, new Vector2Int(-1, -1));
        TryToOpenCellValueNearly(genPosotion, new Vector2Int(0, -1));
        TryToOpenCellValueNearly(genPosotion, new Vector2Int(1, -1));
        TryToOpenCellValueNearly(genPosotion, new Vector2Int(1, 0));
    }
    private void TryToOpenCellValueNearly(Vector2Int origin, Vector2Int offset)
    {
        bool isSpaceOffSetX = origin.x + offset.x <= intMap.GetLength(0) - 1 && origin.x + offset.x >= 0;
        bool isSpaceoffSetY = origin.y + offset.y <= intMap.GetLength(1) - 1 && origin.y + offset.y >= 0;

        if (isSpaceOffSetX && isSpaceoffSetY)
        {
            cellMap[origin.x + offset.x, origin.y + offset.y].OpenCell();
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
            Vector2Int pos= new Vector2Int(Random.Range(0,mapSize.x), Random.Range(0,mapSize.y));
            if(intMap[pos.x, pos.y]>=0)
            {
                intMap[pos.x, pos.y] = -999;
                spawned++;
            }
            
        }
    }
    
    
}
