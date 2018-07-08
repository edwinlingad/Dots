using Assets.Scripts.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page02_03 : PageBase {
    public override PageLocation PageTextLocation => PageLocation.Top;
    public override string PageText => "Rub the bottom dot";

    public Page02_03(Controller controller) : base(controller) {
    }

    protected override void OnPressed11(DotBehavior dot) {
        if (_isPressed == true)
            return;
        _isPressed = true;

        DelayedRunWithGotoNextPage(() => {
            ColorUtil.ChangeColor(dot, MaterialColorEnum.Orange);
        }, AnyActionDelay);
    }
}
