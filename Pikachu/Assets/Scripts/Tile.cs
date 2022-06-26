using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;

    public BaseBall occupiedUnit;

    public bool Walkable => occupiedUnit == null;

    public void Init(bool isOffSet)
    {
        spriteRenderer.color = isOffSet ? 
                               new Color(baseColor.r, baseColor.g, baseColor.b) : 
                               new Color(offsetColor.r, offsetColor.g, offsetColor.b);    
    }



    private void OnMouseEnter()
    {
       highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (GameManager.instance.gameState != GameState.StartTurn)
        {
            return;
        }

        if (occupiedUnit != null)
        {
            if (occupiedUnit.type != Type.QueueBall)
            {
                UnitManager.instance.SetSelectedBall(occupiedUnit);
            }
        }
        else
        {
            if (UnitManager.instance.selectedBall != null)
            {
                if (UnitManager.instance.selectedBall.transform.position.x - this.transform.position.x != 0 
                    && UnitManager.instance.selectedBall.transform.position.y - this.transform.position.y != 0)
                {
                    Debug.Log("Invalid Move");
                }
                else if (UnitManager.instance.selectedBall.transform.position.x - this.transform.position.x != 0 
                    || UnitManager.instance.selectedBall.transform.position.y - this.transform.position.y != 0)
                {
                    SetUnit(UnitManager.instance.selectedBall);
                    UnitManager.instance.SetSelectedBall(null);
                }
            }
        }
    }

    public void SetUnit(BaseBall unit)
    {
        if (unit.occupiedTile != null)
        {
            unit.occupiedTile.occupiedUnit = null;
        }

        unit.transform.position = transform.position;
        occupiedUnit = unit;
        unit.occupiedTile = this;
    }
}
