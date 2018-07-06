using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    public static Rect GetPlayAreaBounds(MonoBehaviour obj)
    {
        float distance = obj.transform.position.z - Camera.main.transform.position.z;
        var leftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        var rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

        Rect rect = new Rect(leftBottom.x, leftBottom.y, rightTop.x, rightTop.y);
        return rect;
    }
}
