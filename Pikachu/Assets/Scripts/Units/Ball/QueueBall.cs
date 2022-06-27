using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueBall : BaseBall
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public SpriteRenderer GetSpriteRenderer()
    {
        return spriteRenderer;
    }
}
