using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page03 : PageBase {
    public override string PageInstruction => "Rub the left dot";

    public Page03(Controller controller) : base(controller) {
    }

    protected override void OnPressed02(DotBehavior dot) {
        if (_isPressed == true)
            return;
        _isPressed = true;

        ChangeColorAndGotoNextPage(dot, Color.red);
    }
}