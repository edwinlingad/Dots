﻿using Assets.Scripts.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page03 : PageBase {
    public override string PageText => "Rub the dot on the left";

    public Page03(Controller controller) : base(controller) {
    }

    protected override void OnPressed02(DotBehavior dot) {
        if (_isPressed == true)
            return;
        _isPressed = true;

        DelayedRunWithGotoNextPage(() => {
            ColorUtil.ChangeColor(dot, MaterialColorEnum.Red);
        }, AnyActionDelay);
    }
}