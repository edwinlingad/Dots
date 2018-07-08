using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page07 : PageBase {
    private int _startIdx = 4;
    public override string PageText => "Press the red dot 4 times";

    public Page07(Controller controller) : base(controller) {
    }

    protected override void OnPressed02(DotBehavior dot) {
        if (_isPressed == true)
            return;

        ShowDot(_numTimePressed++ + _startIdx);
        if (_numTimePressed >= 4) {
            GotoNextPage();
            _isPressed = true;
        }
    }
}

