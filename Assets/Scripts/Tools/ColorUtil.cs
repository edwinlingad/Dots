using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Tools {
    public static class ColorUtil {
        private static Controller _controller;
        public static Controller Controller => _controller ?? (_controller = Controller.Instance);

        public static void ChangeColor(DotBehavior dot, MaterialColorEnum color) {
            var renderer = dot.GetComponent<Renderer>();
            renderer.material = Controller.Materials[(int)color];
        }

        public static void ChangeColor(GameObject dot, MaterialColorEnum color) {
            var renderer = dot.GetComponent<Renderer>();
            renderer.material = Controller.Materials[(int)color];
        }

    }
}
