using System;
using System.Collections.Generic;
using UnityEngine;

namespace AscensiveSoftware.Tools
{
    struct BoundRect
    {
        public float xMin;
        public float xMax;
        public float yMin;
        public float yMax;
        public float width;
        public float height;

        public BoundRect(float xMin, float xMax, float yMin, float yMax)
        {
            this.xMin = xMin;
            this.xMax = xMax;
            this.yMin = yMin;
            this.yMax = yMax;
            width = Mathf.Abs(xMin) + Mathf.Abs(xMax);
            height = Mathf.Abs(yMin) + Mathf.Abs(yMax);
        }
    }

    static class ScreenUtil
    {
        public static BoundRect GetScreenBounds(MonoBehaviour obj)
        {
            float distance = obj.transform.position.z - Camera.main.transform.position.z;
            return ComputeScreenBounds(distance);
        }

        public static BoundRect GetScreenBounds()
        {
            float distance = 10;
            return ComputeScreenBounds(distance);
        }

        private static BoundRect ComputeScreenBounds(float distance)
        {
            var leftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
            var rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

            BoundRect rect = new BoundRect(leftBottom.x, rightTop.x, leftBottom.y, rightTop.y);
            return rect;
        }
    }
}
