using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    [SerializeField]
    public MonoBehaviourHelper Helper;

    #region Configurables
    [SerializeField]
    private Text PageText;
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
        StartCoroutine(DelayedGotoNextPage());
    }

    private IEnumerator DelayedGotoNextPage() {
        yield return new WaitForSeconds(0.5f);
        CurrentPage = Pages[_currentIndex];
        PageText.text = CurrentPage.PageInstruction;
    }

    public void GotoPrevPage() {
        if (_currentIndex < 0)
            return;

        _currentIndex--;
        CurrentPage = Pages[_currentIndex];
    }

    public void OnPressed(DotBehavior dot) {
        CurrentPage.OnPressed(dot);
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
