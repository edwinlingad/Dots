using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Page02 : PageBase {
    public override string PageInstruction => "Press the middle dot again";

    public Page02(Controller controller) : base(controller) {
    }

    protected override void OnPressed01(DotBehavior dot) {
        if (_isPressed == true)
            return;
        _isPressed = true;

        ShowDotAndGotoNextPage(3);
    }
}
