using System;
using System.Collections.Generic;
using UnityEngine;

namespace AscensiveSoftware.Tools
{
    class GizmosRenderer : MonoBehaviour
    {
        public bool showScreenBounds = true;

        private void OnDrawGizmos()
        {
            if (showScreenBounds == true) DisplayScreenBounds();
        }

        private void DisplayScreenBounds()
        {
            float distance = transform.position.z - Camera.main.transform.position.z;
            var leftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
            var rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

            float xSize = Mathf.Abs(leftBottom.x) + Mathf.Abs(rightTop.x);
            float ySize = Mathf.Abs(leftBottom.y) + Mathf.Abs(rightTop.y);

            Gizmos.DrawWireCube(Vector3.zero, new Vector3(xSize, ySize, 0));
        }
    }
}

