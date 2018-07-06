using AscensiveSoftware.Tools;
using AscensiveSoftware.Tools.Tools;
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

    private const float _tiltVariation = 0.3f;

    [SerializeField]
    public Camera Camera;
    [SerializeField]
    private Text _pageTextBottom;
    [SerializeField]
    private Text PageTextTop;
    [SerializeField]
    private GameObject _leftWall;
    [SerializeField]
    private GameObject _rightWall;
    [SerializeField]
    private GameObject _topWall;
    [SerializeField]
    private GameObject _bottomWall;

    #region Configurables
    public GameObject[] Dots;
    #endregion

    private int _currentIndex = -1;
    private int _totalPages;
    private List<PageBase> Pages;
    public PageBase CurrentPage { get; private set; }

    private UiTextUtil _bottomTextUtil;

    public bool TiltEnabled { get; set; } = true;

    private void Start() {
        _bottomTextUtil = new UiTextUtil(this, _pageTextBottom);
        SetUpWalls();
        Pages = GetPages();
        _totalPages = Pages.Count;
        GotoNextPage();
    }

    private void SetUpWalls() {
        var bounds = ScreenUtil.GetScreenBounds(this);
        _leftWall.transform.position = new Vector3(bounds.xMin, 0, 0);
        _rightWall.transform.position = new Vector3(bounds.xMax, 0, 0);
        _topWall.transform.position = new Vector3(0, bounds.yMax, 0);
        _bottomWall.transform.position = new Vector3(0, bounds.yMin, 0);
    }

    private void Update() {
        if (TiltEnabled == false)
            return;

        float x = Input.acceleration.x * 10;
        float y = Input.acceleration.y * 10;
        Physics.gravity = new Vector3(x, y, 0);
    }

    public void GotoNextPage() {
        if (_currentIndex >= _totalPages - 1)
            return;

        _currentIndex++;
        CurrentPage = Pages[_currentIndex];
        ShowPageText();
    }

    private void ShowPageText() {
        _bottomTextUtil.TypeText(CurrentPage.PageText);
        _pageTextBottom.color = CurrentPage.PageTextColor;
        //if (CurrentPage.PageTextLocation == PageLocation.Bottom) {
        //    _bottomTextUtil.TypeText(CurrentPage.PageText);
        //    _pageTextBottom.color = CurrentPage.PageTextColor;
        //    //PageTextTop.text = "";
        //    //_pageTextBottom.text = CurrentPage.PageText;
        //    return;
        //}

        //if(CurrentPage.PageTextLocation == PageLocation.Top) {
        //    _pageTextBottom.text = "";
        //    PageTextTop.text = CurrentPage.PageText;
        //    PageTextTop.color = CurrentPage.PageTextColor;
        //}
    }

    public void GotoPrevPage() {
        if (_currentIndex < 0)
            return;

        _currentIndex--;
        CurrentPage = Pages[_currentIndex];
    }

    public void SetPageText(string text) {
        _pageTextBottom.text = text;
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

    public void OnTiltLeft() {
        Physics.gravity = new Vector3(-10, _tiltVariation * -1);
    }

    public void OnTiltRight() {
        Physics.gravity = new Vector3(10, _tiltVariation);
    }
    public void OnTiltUp() {
        Physics.gravity = new Vector3(0, 10);
    }

    public void OnTiltDown() {
        Physics.gravity = new Vector3(0, -10);
    }

    private List<PageBase> GetPages() {
        return new List<PageBase>
        {
            new Page01(this),   // middle
            new Page02(this),   // left
            new Page02_01(this), // right 
            new Page02_02(this), // top
            new Page02_03(this), // bottom color
            new Page02_04(this), // top color
            new Page02_05(this),   // right color
            new Page03(this),   // left color
            new Page05(this), // middle color
            new Page06(this),
            new Page07(this),
            new Page08(this),
            new Page09(this),
            new Page10(this),
            new Page11(this), // Black Screen
            new Page12(this), // Black Screen 2
            new Page13(this),
        };
    }
}
