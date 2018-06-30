using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page05 : PageBase {
    public override string PageInstruction => "Rub the middle dot";

    public Page05(Controller controller) : base(controller) {
    }

    protected override void OnPressed01(DotBehavior dot) {
        if (_isPressed == true)
            return;
        _isPressed = true;

        ChangeColorAndGotoNextPage(dot, new Color(255, 223, 0));
    }
}
