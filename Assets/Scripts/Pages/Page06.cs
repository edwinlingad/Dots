using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page06 : PageBase {
    private int _startIdx = 12;
    public override string PageText => "Press the blue dot 4 times";

    public Page06(Controller controller) : base(controller) {
    }

    protected override void OnPressed03(DotBehavior dot) {
        if (_isPressed == true)
            return;

        ShowDot(_numTimePressed++ + _startIdx);
        if (_numTimePressed >= 4) {
            GotoNextPage();
            _isPressed = true;
        }
    }
}
