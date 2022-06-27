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

    
    private bool IsMoveValid(Vector2 startPoint, Vector2 endPoint, float offSetX, float offSetY)
    {

        if (offSetY == 0)
        {
            if (offSetX > 0f)
            {
                for (float i = startPoint.x + 1; i < startPoint.x + offSetX; ++i)
                {
                    BaseBall currUnit = GridManager.instance.GetTileAtPosition(new Vector2(i, startPoint.y)).occupiedUnit;
                    if (currUnit != null && currUnit.type != Type.QueueBall)
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (float i = startPoint.x - 1; i > startPoint.x + offSetX; --i)
                {
                    BaseBall currUnit = GridManager.instance.GetTileAtPosition(new Vector2(i, startPoint.y)).occupiedUnit;
                    if ( currUnit != null && currUnit.type != Type.QueueBall)
                    {
                        return false;
                    }
                }
            }
        }
        else if (offSetX == 0)
        {
            if (offSetY > 0f)
            {
                for (float j = startPoint.y + 1; j < startPoint.y + offSetY; ++j)
                {
                    BaseBall currUnit = GridManager.instance.GetTileAtPosition(new Vector2(startPoint.x, j)).occupiedUnit;
                    if ( currUnit != null && currUnit.type != Type.QueueBall)
                    {
                        return false; 
                    }
                }
            }
            else
            {
                for (float j = startPoint.y - 1; j > startPoint.y + offSetY; --j)
                {
                    BaseBall currUnit = GridManager.instance.GetTileAtPosition(new Vector2(startPoint.x, j)).occupiedUnit;
                    if ( currUnit != null && currUnit.type != Type.QueueBall)
                    {
                        return false;
                    }
                }
            }
        }
        return true;
     
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
            if (UnitManager.instance.selectedBall.type == Type.GhostBall)
            {
                SetUnit(UnitManager.instance.selectedBall);
                UnitManager.instance.SetSelectedBall(null);
                GameManager.instance.ChangeState(GameState.EndTurn);
                return;
            }


            Vector2 startPoint = UnitManager.instance.selectedBall.transform.position;
            Vector2 endPoint = this.transform.position;

            float offSetX = endPoint.x - startPoint.x;
            float offSetY = endPoint.y - startPoint.y;

            Debug.Log(offSetX + "  " + offSetY);

            if (UnitManager.instance.selectedBall != null)
            {
                if (offSetX != 0 && offSetY != 0)
                {
                    Debug.Log("Invalid Move");
                }

                else if (offSetX != 0 || offSetY != 0)
                {
                    if (IsMoveValid(startPoint, endPoint, offSetX, offSetY))
                    {
                        SetUnit(UnitManager.instance.selectedBall);
                        UnitManager.instance.SetSelectedBall(null);
                    }
                    else
                    {
                        Debug.Log("Invalid Move");
                    }
                    GameManager.instance.ChangeState(GameState.EndTurn);
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
