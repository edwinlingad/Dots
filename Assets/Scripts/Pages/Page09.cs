using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page09 : PageBase {

    public override string PageText => "Press the middle yellow dot";
    

    public Page09(Controller controller) : base(controller) {
    }

    protected override void OnPressed01(DotBehavior dot) {
        if (_isPressed == true)
            return;

        _isPressed = true;
        Controller.Camera.backgroundColor = Color.black;
        for (int i = 1; i < 15; i++)
        {
            Controller.Dots[i].SetActive(false);
        }

        GotoNextPage();
    }
}
