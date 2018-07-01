using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page04 : PageBase {
    public override PageLocation PageTextLocation => PageLocation.Top;
    public override string PageText => "Rub the right dot";

    public Page04(Controller controller) : base(controller) {
    }

    protected override void OnPressed03(DotBehavior dot) {
        if (_isPressed == true)
            return;
        _isPressed = true;

        DelayedRunWithGotoNextPage(() => {
            dot.Material.color = Color.blue;
        }, AnyActionDelay);
    }
}
