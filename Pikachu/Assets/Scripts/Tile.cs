using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;


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
}
