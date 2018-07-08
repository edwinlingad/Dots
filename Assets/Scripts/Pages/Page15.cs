﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page15 : PageBase {
    public override string PageText => "Last but not least, the yellow dots";
    public override Color PageTextColor => Color.black;
    private int _count = 0;

    public Page15(Controller controller) : base(controller) {
    }

    protected override void OnPressed01(DotBehavior dot) {
        HideMe(dot);
    }

    protected override void OnPressed08(DotBehavior dot) {
        HideMe(dot);
    }

    protected override void OnPressed09(DotBehavior dot) {
        HideMe(dot);
    }

    protected override void OnPressed10(DotBehavior dot) {
        HideMe(dot);
    }

    protected override void OnPressed11(DotBehavior dot) {
        HideMe(dot);
    }

    private void HideMe(DotBehavior dot) {
        DelayedRun(() => {
            _count++;
            HideDot(dot.Id + 1);
            if (_count >= 3) {
                GotoNextPage();
            }
        }, AnyActionDelay);
    }
}

