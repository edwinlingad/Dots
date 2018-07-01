using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageBase {

    public const float AnyActionDelay = 0.5f;
    public const float NextPageDelay = 0.25f;

    protected bool _isPressed = false;
    protected int _numTimePressed = 0;

    public virtual PageLocation PageTextLocation { get; } = PageLocation.Bottom;
    public virtual string PageText { get; }
    public virtual Color PageTextColor { get; } = Color.black;

    protected Controller Controller;
    private List<Action<DotBehavior>> _actions;

    public PageBase(Controller controller) {
        Controller = controller;
        _actions = GetActions();
    }

    public void OnPressed(DotBehavior dot) {
        _actions[dot.Id](dot);
    }

    private List<Action<DotBehavior>> GetActions() {
        return new List<Action<DotBehavior>>
        {
            OnPressed01,
            OnPressed02,
            OnPressed03,
            OnPressed04,
            OnPressed05,
            OnPressed06,
            OnPressed07,
            OnPressed08,
            OnPressed09,
            OnPressed10,
        };
    }

    protected virtual void OnPressed01(DotBehavior dot) {

    }

    protected virtual void OnPressed02(DotBehavior dot) {

    }

    protected virtual void OnPressed03(DotBehavior dot) {

    }

    protected virtual void OnPressed04(DotBehavior dot) {

    }

    protected virtual void OnPressed05(DotBehavior dot) {

    }

    protected virtual void OnPressed06(DotBehavior dot) {

    }

    protected virtual void OnPressed07(DotBehavior dot) {

    }

    protected virtual void OnPressed08(DotBehavior dot) {

    }

    protected virtual void OnPressed09(DotBehavior dot) {

    }

    protected virtual void OnPressed10(DotBehavior dot) {

    }

    protected void DelayedRun(Action action, float sec) {
        Controller.DelayedRun(action, sec);
    }

    protected void DelayedRunWithGotoNextPage(Action action, float sec) {
        Controller.DelayedRunWithGotoNextPage(action, sec);
    }

    protected void SetPageText(string text) {
        Controller.SetPageText(text);
    }

    protected void ShowDot(int id, string text = null) {
        Controller.Dots[id - 1].SetActive(true);
    }

    protected void HideDot(int id) {
        Controller.Dots[id-1].SetActive(false);
    }

    protected void GotoNextPage() {
        Controller.GotoNextPage();
    }
}
