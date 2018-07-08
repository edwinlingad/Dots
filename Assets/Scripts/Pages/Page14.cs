using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page14 : PageBase {
    public override string PageText => "Same, but the blue ones";
    public override Color PageTextColor => Color.black;
    private int _count = 0;

    public Page14(Controller controller) : base(controller) {
    }

    protected override void OnPressed03(DotBehavior dot) {
        HideMe(dot);
    }

    protected override void OnPressed12(DotBehavior dot) {
        HideMe(dot);
    }

    protected override void OnPressed13(DotBehavior dot) {
        HideMe(dot);
    }

    protected override void OnPressed14(DotBehavior dot) {
        HideMe(dot);
    }

    protected override void OnPressed15(DotBehavior dot) {
        HideMe(dot);
    }

    private void HideMe(DotBehavior dot) {
        DelayedRun(() => {
            _count++;
            HideDot(dot.Id + 1);
            if (_count >= 5) {
                GotoNextPage();
            }
        }, AnyActionDelay);
    }
}

