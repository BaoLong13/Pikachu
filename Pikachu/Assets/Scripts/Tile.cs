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
