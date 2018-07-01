using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page08 : PageBase {
    public override string PageText => "Press the red dot 5 times";

    public Page08(Controller controller) : base(controller) {
    }

    protected override void OnPressed02(DotBehavior dot) {
        if (_isPressed == true)
            return;

        if (_numTimePressed >= 4)
        {
            GotoNextPage();
            _isPressed = true;
            return;
        }

        ShowDot(_numTimePressed + 4);
        _numTimePressed++;
    }
}

