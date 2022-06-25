using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit" ,menuName = "Scriptable Unit")]

public class ScriptableUnit : ScriptableObject
{
    public Type unitType;
    public BaseUnit unitPrefab;
}

public enum Type
{
    Ball = 0,
    QueueBall = 1,
    GhostBall =2
}