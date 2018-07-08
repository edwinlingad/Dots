using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page13 : PageBase {
    public override string PageText => "Press all the red dots in any order";
    public override Color PageTextColor => Color.black;
    private int _count = 0;

    public Page13(Controller controller) : base(controller) {
    }

    protected override void OnPressed02(DotBehavior dot) {
        HideMe(dot);
    }

    protected override void OnPressed04(DotBehavior dot) {
        HideMe(dot);
    }

    protected override void OnPressed05(DotBehavior dot) {
        HideMe(dot);
    }

    protected override void OnPressed06(DotBehavior dot) {
        HideMe(dot);
    }

    protected override void OnPressed07(DotBehavior dot) {
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

