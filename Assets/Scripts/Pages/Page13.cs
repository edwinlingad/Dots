using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page13 : PageBase {
    public override string PageText => "Tap the dot in the middle";
    public override Color PageTextColor => Color.black;

    public Page13(Controller controller) : base(controller) {
    }

    protected override void OnPressed01(DotBehavior dot) {
        if (_isPressed == true)
            return;
        _isPressed = true;

        DelayedRunWithGotoNextPage(() => {
            ShowDot(2);
        }, AnyActionDelay);
    }
}

