using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Page02_01 : PageBase {
    public override PageLocation PageTextLocation => PageLocation.Top;
    public override string PageText => "Tap the dot on the right";

    public Page02_01(Controller controller) : base(controller) {
    }

    protected override void OnPressed03(DotBehavior dot) {
        if (_isPressed == true)
            return;
        _isPressed = true;

        DelayedRunWithGotoNextPage(() => {
            ShowDot(10);
        }, AnyActionDelay);
    }
}