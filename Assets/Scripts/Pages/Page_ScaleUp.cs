using Assets.Scripts.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Page_ScaleUp : PageBase {

    public override string PageText => "Tap the dot";

    public Page_ScaleUp(Controller controller) : base(controller) {
    }

    protected override void OnPressed01(DotBehavior dot) {
        DelayedRun(() => {
            ScaleUtil.MakeBigger(dot);
        }, AnyActionDelay);
        
    }
}

