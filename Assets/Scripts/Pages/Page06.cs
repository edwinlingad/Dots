using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page06 : PageBase {
    private int _startIdx = 12;
    public override string PageText => "Press the blue dot 5 times";

    public Page06(Controller controller) : base(controller) {
    }

    protected override void OnPressed03(DotBehavior dot) {
        if (_isPressed == true)
            return;

        if (_numTimePressed >= 4)
        {
            GotoNextPage();
            _isPressed = true;
            return;
        }

        if (_numTimePressed >= 3)
        {
            ShowDot(_numTimePressed++ + _startIdx, "Come on, one last time");
            return;
        }

        ShowDot(_numTimePressed++ + _startIdx);
    }
}
