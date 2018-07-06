using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page02_04 : PageBase {
    public override PageLocation PageTextLocation => PageLocation.Top;
    public override string PageText => "Rub the top dot";
    
    public Page02_04(Controller controller) : base(controller) {
    }

    protected override void OnPressed10(DotBehavior dot) {
        if (_isPressed == true)
            return;
        _isPressed = true;

        DelayedRunWithGotoNextPage(() => {
            dot.Material.color = Color.green;
        }, AnyActionDelay);
    }
}
