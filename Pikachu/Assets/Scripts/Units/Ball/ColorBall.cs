using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBall : BaseBall
{
    public SpriteRenderer spriteRenderer;
    void Start()
    {
       spriteRenderer = GetComponent<SpriteRenderer>();
    }

}
