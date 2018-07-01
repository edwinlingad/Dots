using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PageLocation {
    Top,
    Bottom
};

public class Controller : MonoBehaviour {

    [SerializeField]
    public MonoBehaviourHelper Helper;
    [SerializeField]
    public Camera Camera;
    [SerializeField]
    private Text PageTextBottom;
    [SerializeField]
    private Text PageTextTop;

    #region Configurables
    public GameObject[] Dots;
    #endregion

    private int _currentIndex = -1;
    private int _totalPages;
    private List<PageBase> Pages;
    public PageBase CurrentPage { get; private set; }
    
    private void Start() {
        Pages = GetPages();
        _totalPages = Pages.Count;
        GotoNextPage();
        Helper.Controller = this;
    }

    public void GotoNextPage() {
        if (_currentIndex >= _totalPages - 1)
            return;

        _currentIndex++;
        CurrentPage = Pages[_currentIndex];
        ShowPageText();
    }

    private void ShowPageText() {
        if(CurrentPage.PageTextLocation == PageLocation.Bottom) {
            PageTextTop.text = "";
            PageTextBottom.text = CurrentPage.PageText;
            PageTextBottom.color = CurrentPage.PageTextColor;
            return;
        }

        if(CurrentPage.PageTextLocation == PageLocation.Top) {
            PageTextBottom.text = "";
            PageTextTop.text = CurrentPage.PageText;
            PageTextTop.color = CurrentPage.PageTextColor;
        }
    }

    public void GotoPrevPage() {
        if (_currentIndex < 0)
            return;

        _currentIndex--;
        CurrentPage = Pages[_currentIndex];
    }

    public void SetPageText(string text) {
        PageTextBottom.text = text;
    }

    public void OnPressed(DotBehavior dot) {
        CurrentPage.OnPressed(dot);
    }

    public void DelayedRun(Action action, float sec) {
        StartCoroutine(DoDelayedRun(action, sec));
    }

    public void DelayedRunWithGotoNextPage(Action action, float sec) {
        StartCoroutine(DoDelayedRun(() => {
            action?.Invoke();
            DelayedRun(() => {
                GotoNextPage();
            }, PageBase.NextPageDelay);
        }, sec));
    }

    private IEnumerator DoDelayedRun(Action action, float sec) {
        yield return new WaitForSeconds(sec);
        action?.Invoke();
    }

    private List<PageBase> GetPages() {
        return new List<PageBase>
        {
            new Page01(this),
            new Page02(this),
            new Page03(this),
            new Page04(this),
            new Page05(this),
            new Page06(this),
            new Page07(this),
            new Page08(this),
            new Page09(this),
            new Page10(this),
            new Page11(this),
            new Page12(this),
        };
    }
}
