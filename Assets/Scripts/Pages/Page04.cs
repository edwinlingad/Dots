using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page04 : PageBase {
    public override string PageInstruction => "Rub the right dot";

    public Page04(Controller controller) : base(controller) {
    }

    protected override void OnPressed03(DotBehavior dot) {
        if (_isPressed == true)
            return;
        _isPressed = true;

        ChangeColorAndGotoNextPage(dot, Color.blue);
    }
}
