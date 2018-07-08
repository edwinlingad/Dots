using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page10 : PageBase {

    public override string PageText => "Press the yellow dot again";
    public override Color PageTextColor => Color.white;

    public Page10(Controller controller) : base(controller) {
    }

    protected override void OnPressed01(DotBehavior dot) {
        if (_isPressed == true)
            return;

        _isPressed = true;
        Controller.Camera.backgroundColor = Color.white;
        for (int i = 1; i < 15; i++)
        {
            Controller.Dots[i].SetActive(true);
        }

        GotoNextPage();
    }
}
