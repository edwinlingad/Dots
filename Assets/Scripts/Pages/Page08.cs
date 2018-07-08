using Assets.Scripts.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page08 : PageBase {
    private int _startIdx = 8;
    public override string PageText => "Press the yellow dot 4 times";

    public Page08(Controller controller) : base(controller) {
    }

    protected override void OnPressed01(DotBehavior dot) {
        if (_isPressed == true)
            return;

        if (_numTimePressed >= 3) {
            var dotToChange = Controller.Dots[10];
            ColorUtil.ChangeColor(dotToChange, MaterialColorEnum.Gold);
            _isPressed = true;
            DelayedRun(() => {
                GotoNextPage();
            }, NextPageDelay);
        }
        else if (_numTimePressed >= 2) {
            var dotToChange = Controller.Dots[9];
            ColorUtil.ChangeColor(dotToChange, MaterialColorEnum.Gold);
        }
        else {
            ShowDot(_numTimePressed + _startIdx);
        }
        _numTimePressed++;
    }
}

