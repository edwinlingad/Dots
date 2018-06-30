using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page06 : PageBase {
    public override string PageInstruction => "Press the blue dot 5 times";

    public Page06(Controller controller) : base(controller) {
    }

    protected override void OnPressed03(DotBehavior dot) {
        if (_isPressed == true)
            return;

        if(_numTimePressed >= 4)
        {
            GotoNextPage();
            _isPressed = true;
            return;
        }

        ShowDot(_numTimePressed + 12);
        _numTimePressed++;
    }
}
