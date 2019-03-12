using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class IPoint : MonoBehaviour
{
    const float r = 10;

    public bool InRange(Vector2 pos)
    {
        var center = ToScreenPos(this.transform.position);

        Debug.Log("center" + center);

        var left = (pos.x - center.x) * (pos.x - center.x) + (pos.y - center.y) * (pos.y - center.y);
        var right = r * r;
        return left < right;
    }

    Vector2 ToScreenPos(Vector2 pos)
    {
        return Camera.main.WorldToScreenPoint(pos);
    }
}
