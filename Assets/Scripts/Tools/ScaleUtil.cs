using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tools {
    public static class ScaleUtil {
        private const float _scaleFactor = 0.2f;
        private static Controller _controller;
        public static Controller Controller => _controller ?? (_controller = Controller.Instance);

        private static Vector3 _scaleVector = new Vector3(_scaleFactor, _scaleFactor, _scaleFactor);

        public static void MakeBigger(DotBehavior dot) {
            dot.transform.localScale += _scaleVector;
        }

        public static void MakeSmaller(DotBehavior dot) {
            dot.transform.localScale -= _scaleVector;
        }
    }
}
