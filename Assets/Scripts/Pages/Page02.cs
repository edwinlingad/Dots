using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Page02 : PageBase {
    public override PageLocation PageTextLocation => PageLocation.Top;
    public override string PageText => "Tap the dot on the left";

    public Page02(Controller controller) : base(controller) {
    }

    protected override void OnPressed02(DotBehavior dot) {
        if (_isPressed == true)
            return;
        _isPressed = true;

        DelayedRunWithGotoNextPage(() => {
            ShowDot(3);
        }, AnyActionDelay);
    }
}
