﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page07 : PageBase {
    public override string PageText => "Press the yellow dot 5 times";

    public Page07(Controller controller) : base(controller) {
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

