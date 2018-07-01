using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page01 : PageBase {
    public override string PageText => "Press the dot in the middle";

    public Page01(Controller controller) : base(controller) {
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

