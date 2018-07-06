using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Page02_02 : PageBase {
    public override PageLocation PageTextLocation => PageLocation.Top;
    public override string PageText => "Press the top dot";

    public Page02_02(Controller controller) : base(controller) {
    }

    protected override void OnPressed10(DotBehavior dot) {
        if (_isPressed == true)
            return;
        _isPressed = true;

        DelayedRunWithGotoNextPage(() => {
            ShowDot(11);
        }, AnyActionDelay);
    }
}
