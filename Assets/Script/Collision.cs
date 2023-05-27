using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision
{
    public static bool BoxCollision(Vector2 aPos, Vector2 bPos, Vector2 aSize, Vector2 bSize)
    {
        if(Mathf.Abs(aPos.x - bPos.x) < (aSize.x + bSize.x) / 2 &&
           Mathf.Abs(aPos.y - bPos.y) < (aSize.y + bSize.y) / 2) { return true; }
        else { return false; }
    }
}
