using Assets.Scripts.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Page_SmallDotsToBig : PageBase {
    private int _count;
    private List<int> _dotsToShow;
    private List<bool> _dotsPressed;

    public override string PageText => "Tap the small dots that appear";
    public override Color PageTextColor => Color.white;

    public Page_SmallDotsToBig(Controller controller) : base(controller) {
    }

    public override void Init() {
        base.Init();
        _dotsToShow = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        _dotsPressed = new List<bool>();
        for (int i = 0; i < 15; i++) {
            _dotsPressed.Add(false);
        }
        _count = _dotsToShow.Count - 1;
        ShowNext();
    }

    protected override void OnPressed01(DotBehavior dot) {
        if (_dotsPressed[dot.Id - 1] == true)
            return;
        _dotsPressed[dot.Id - 1] = true;
        ScaleUtil.MakeBiggest(dot);
        ShowNext();
    }

    protected override void OnPressed02(DotBehavior dot) {
        if (_dotsPressed[dot.Id - 1] == true)
            return;
        _dotsPressed[dot.Id - 1] = true;
        ScaleUtil.MakeBiggest(dot);
        ShowNext();
    }

    protected override void OnPressed03(DotBehavior dot) {
        if (_dotsPressed[dot.Id - 1] == true)
            return;
        _dotsPressed[dot.Id - 1] = true;
        ScaleUtil.MakeBiggest(dot);
        ShowNext();
    }

    protected override void OnPressed04(DotBehavior dot) {
        if (_dotsPressed[dot.Id - 1] == true)
            return;
        _dotsPressed[dot.Id - 1] = true;
        ScaleUtil.MakeBiggest(dot);
        ShowNext();
    }

    protected override void OnPressed05(DotBehavior dot) {
        if (_dotsPressed[dot.Id - 1] == true)
            return;
        _dotsPressed[dot.Id - 1] = true;
        ScaleUtil.MakeBiggest(dot);
        ShowNext();
    }

    protected override void OnPressed06(DotBehavior dot) {
        if (_dotsPressed[dot.Id - 1] == true)
            return;
        _dotsPressed[dot.Id - 1] = true;
        ScaleUtil.MakeBiggest(dot);
        ShowNext();
    }

    protected override void OnPressed07(DotBehavior dot) {
        if (_dotsPressed[dot.Id - 1] == true)
            return;
        _dotsPressed[dot.Id - 1] = true;
        ScaleUtil.MakeBiggest(dot);
        ShowNext();
    }

    protected override void OnPressed08(DotBehavior dot) {
        if (_dotsPressed[dot.Id - 1] == true)
            return;
        _dotsPressed[dot.Id - 1] = true;
        ScaleUtil.MakeBiggest(dot);
        ShowNext();
    }

    protected override void OnPressed09(DotBehavior dot) {
        if (_dotsPressed[dot.Id - 1] == true)
            return;
        _dotsPressed[dot.Id - 1] = true;
        ScaleUtil.MakeBiggest(dot);
        ShowNext();
    }

    protected override void OnPressed10(DotBehavior dot) {
        if (_dotsPressed[dot.Id - 1] == true)
            return;
        _dotsPressed[dot.Id - 1] = true;
        ScaleUtil.MakeBiggest(dot);
        ShowNext();
    }

    protected override void OnPressed11(DotBehavior dot) {
        if (_dotsPressed[dot.Id - 1] == true)
            return;
        _dotsPressed[dot.Id - 1] = true;
        ScaleUtil.MakeBiggest(dot);
        ShowNext();
    }

    protected override void OnPressed12(DotBehavior dot) {
        if (_dotsPressed[dot.Id - 1] == true)
            return;
        _dotsPressed[dot.Id - 1] = true;
        ScaleUtil.MakeBiggest(dot);
        ShowNext();
    }

    protected override void OnPressed13(DotBehavior dot) {
        if (_dotsPressed[dot.Id - 1] == true)
            return;
        _dotsPressed[dot.Id - 1] = true;
        ScaleUtil.MakeBiggest(dot);
        ShowNext();
    }

    protected override void OnPressed14(DotBehavior dot) {
        if (_dotsPressed[dot.Id - 1] == true)
            return;
        _dotsPressed[dot.Id - 1] = true;
        ScaleUtil.MakeBiggest(dot);
        ShowNext();
    }

    protected override void OnPressed15(DotBehavior dot) {
        if (_dotsPressed[dot.Id - 1] == true)
            return;
        _dotsPressed[dot.Id - 1] = true;
        ScaleUtil.MakeBiggest(dot);
        ShowNext();
    }

    private void ShowNext() {
        if (_count <= 0) {
            DelayedRun(() => {
                GotoNextPage();
            }, NextPageDelay);
            return;
        }
            
        var randomIdx = UnityEngine.Random.Range(0, _dotsToShow.Count - 1);
        var dotsIdx = _dotsToShow.ElementAt(randomIdx);
        _dotsToShow.RemoveAt(randomIdx);

        var dot = Controller.DotsBehavior[dotsIdx];
        ScaleUtil.MakeSmallest(dot);
        ShowDot(dot.Id + 1);
        _count--;
    }
}
