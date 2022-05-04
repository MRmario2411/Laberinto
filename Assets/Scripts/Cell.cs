using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cell : MonoBehaviour
{

    [SerializeField] private GameObject Inner;
    private Grid grid;
    public bool isWalkable;
    public int x, y ;
    public int gCost, hCost, fCost;
    public Cell pastCell;

    public void Init(Grid grid, int x, int y, bool isWalkable)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        this.isWalkable = isWalkable;

    }

    public Vector2 Position => transform.position;


    //GetLayerMask de la celda
    public int GetLayerMask()
    {
        Debug.Log("Cambio de Layer a " + gameObject.layer);
        return gameObject.layer;
    }
    //SetLayerMask de la celda
    public void SetLayerMask(int layer)
    {
        gameObject.layer = layer;
    }
    public void SetColor(Color color)
    {
        Inner.GetComponent<SpriteRenderer>().color = color;
    }
   void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            grid.CellMouseClick(this);
        }
    }

    private void OnMouseDown()
    {
        
        if (Input.GetMouseButton(0))
        {
            
        } 
    }

    internal void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    internal void SetWalkable(bool v)
    {
        isWalkable = v;
        SetColor(Color.red);
    }

    public override string ToString()
    {
        return "Cell "+x + "," + y;
    }
}
