using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Grid : ScriptableObject
{
    private int width;
    private int height;
    private int cellSize;
    private LayerMask mascara;
    private Cell cellPrefab;
    
    private Cell[,] gridArray;


    public Grid(int width, int height, int cellSize, Cell cellPrefab, LayerMask masc)
    {
        
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.cellPrefab = cellPrefab;
        this.mascara = masc;
        generateBoard();
    }

    private void generateBoard()
    {
        var cont = 20;  
        Cell cell;
        gridArray = new Cell[width, height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var p = new Vector2(i, j) * cellSize;
                cell = Instantiate(cellPrefab, p, Quaternion.identity);
                cell.Init(this, (int)p.x, (int)p.y, true);

                if (Random.Range(0, 5) == 2 && cont>=1){
                    //cambiar el LayerMask de la clase Cell a mascara
                    int v=cell.GetLayerMask();
                    cell.SetLayerMask(v+3);
                    cell.SetWalkable(false);
                    cont=cont-1;

                }else{
                    cell.SetColor(Color.blue);
                }
                gridArray[i, j] = cell;
            }
        }

        var center = new Vector2((float)height / 2 - 0.5f, (float)width / 2 - 0.5f);

        Camera.main.transform.position = new Vector3(center.x, center.y, -5);
    }

    internal int GetHeight()
    {
        return height;
    }

    internal int GetWidth()
    {
        return width;
    }

    public void CellMouseClick(Cell cell)
    {
        BoardManager.Instance.CellMouseClick(cell.x, cell.y);
    }

    

    public Cell GetGridObject(int x, int y)
    {
        return gridArray[x, y];
    }

    internal float GetCellSize()
    {
        return cellSize;
    }
}
