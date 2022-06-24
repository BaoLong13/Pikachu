using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void Init(bool isOffSet)
    {
        spriteRenderer.color = isOffSet ? 
                               new Color(baseColor.r, baseColor.g, baseColor.b) : 
                               new Color(offsetColor.r, offsetColor.g, offsetColor.b);    
    }
}
