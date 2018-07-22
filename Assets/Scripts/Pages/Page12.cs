using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page12 : PageBase {

    public override string PageText => "Tilt to the right";
    public override Color PageTextColor => Color.black;

    public Page12(Controller controller) : base(controller) {
    }

    protected override void OnPressed01(DotBehavior dot) {
        if (_isPressed == true)
            return;

        _isPressed = true;
    }
}
