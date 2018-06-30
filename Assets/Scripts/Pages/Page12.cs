using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page12 : PageBase {

    public override string PageInstruction => "Press the yellow dot again";

    public Page12(Controller controller) : base(controller) {
    }

    protected override void OnPressed01(DotBehavior dot) {
        if (_isPressed == true)
            return;

        if (_numTimePressed >= 4)
        {
            GotoNextPage();
            _isPressed = true;
            return;
        }

        ShowDot(_numTimePressed + 8);
        _numTimePressed++;
    }
}
