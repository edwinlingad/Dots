using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page11 : PageBase {

    public override string PageText => "Tilt to the left";
    public override Color PageTextColor => Color.black;

    public Page11(Controller controller) : base(controller) {
    }

    public override void Init() {
        Controller.IsTiltEnabled = true;
    }

    protected override void OnPressed01(DotBehavior dot) {
        if (_isPressed == true)
            return;

        _isPressed = true;
    }
}
