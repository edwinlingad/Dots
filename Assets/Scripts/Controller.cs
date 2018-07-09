using AscensiveSoftware.Tools;
using AscensiveSoftware.Tools.Tools;
using Assets.Scripts.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum PageLocation {
    Top,
    Bottom
};

public enum MaterialColorEnum {
    Black = 0,
    Blue = 1,
    Gold = 2,
    Red = 3,
    Orange = 4,
    Green = 5,
}

public class Controller : MonoBehaviour {

    public static bool IsGlobalDragEnabled { get; set; } = false;
    public static Controller Instance { get; set; }
    public bool IsMicInputEnabled { get; set; } = false;

    private const float _tiltVariation = 0.3f;
    private MicInput _micInput;

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
    public Material[] Materials;
    public GameObject[] Dots;
    public List<DotBehavior> DotsBehavior { get; private set; }
    #endregion

    private int _currentIndex = -1;
    private int _totalPages;
    private List<PageBase> Pages;
    public PageBase CurrentPage { get; private set; }

    private UiTextUtil _bottomTextUtil;
    private float _loudnessThreshold = 1.0f;

    public bool TiltEnabled { get; set; } = true;

    private void Awake() {
        Instance = this;
        _micInput = gameObject.GetComponent<MicInput>();
        DotsBehavior = new List<DotBehavior>();
        foreach (var item in Dots) {
            var dots = item.GetComponent<DotBehavior>();
            DotsBehavior.Add(dots);
        }
    }

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
        if (TiltEnabled == true) {
            float x = Input.acceleration.x * 10;
            float y = Input.acceleration.y * 10;
            Physics.gravity = new Vector3(x, y, 0);
        }

        //if(IsMicInputEnabled == true) {
        //    var loudness = _micInput.loudness;
        //    PageTextTop.text = $" Loudness = {loudness}";
        //    if (loudness > _loudnessThreshold) {
        //        PageTextTop.text = $" Loudness = {loudness}";
        //    }
        //}

    }

    public void GotoNextPage() {
        if (_currentIndex >= _totalPages - 1) {
            GotoEndPage();
            return;
        }

        _currentIndex++;
        CurrentPage = Pages[_currentIndex];
        CurrentPage.Init();
        ShowPageText();
    }

    public void GotoEndPage() {
        SceneManager.LoadScene(2);
    }

    private void ShowPageText() {
        _bottomTextUtil.TypeText(CurrentPage.PageText);
        _pageTextBottom.color = CurrentPage.PageTextColor;
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
            new Page06(this), // Dup Blue
            new Page08(this), // Dup Yellow
            new Page07(this), // Dup Red
            new Page09(this), // Yellow Dot - bg black
            new Page_SmallDotsToBig(this),
            //new Page10(this), // Yellow Dot 2
            ////new Page11(this), // Tilt Left
            ////new Page12(this), // Tilt Right
            new Page13(this), // Dis Red
            new Page14(this), // Dis Blue
            new Page15(this), // Dis Yellow
            //new Page_ScaleUp(this)
        };
    }


}
