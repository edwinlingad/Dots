using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page05 : PageBase {
    public override string PageText => "Rub the middle dot";

    public Page05(Controller controller) : base(controller) {
    }

    protected override void OnPressed01(DotBehavior dot) {
        if (_isPressed == true)
            return;
        _isPressed = true;

        DelayedRunWithGotoNextPage(() => {
            dot.Material.color = Color.yellow;
        }, AnyActionDelay);
    }
}
