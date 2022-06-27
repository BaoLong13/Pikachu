using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBall : BaseBall
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    public SpriteRenderer GetSpriteRenderer()
    {
        return spriteRenderer;
    }
}
