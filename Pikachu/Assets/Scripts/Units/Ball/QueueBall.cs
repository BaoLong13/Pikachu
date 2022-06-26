using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueBall : BaseBall
{
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
