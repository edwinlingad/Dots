using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviourHelper : MonoBehaviour {

    public Controller Controller { get; set; }

    public void ChangeColorAndGotoNextPage(DotBehavior dot, Color color) {
        StartCoroutine(DelayedChangeColor(dot, color));
    }

    public IEnumerator DelayedChangeColor(DotBehavior dot, Color color) {
        yield return new WaitForSeconds(1f);
        dot.Material.color = color;
        Controller.GotoNextPage();
    }

    public void ShowDot(GameObject dot, string text = null) {
        StartCoroutine(DelayedShowDot(dot, text));
    }

    public IEnumerator DelayedShowDot(GameObject dot, string text = null) {
        yield return new WaitForSeconds(0.5f);
        dot.SetActive(true);
        if (string.IsNullOrEmpty(text) == false)
            Controller.SetPageText(text);
    }

    public void ShowDotAndGotoNextPage(GameObject dot) {
        StartCoroutine(DelayedShowDotAndGotoNextPage(dot));
    }

    public IEnumerator DelayedShowDotAndGotoNextPage(GameObject dot) {
        yield return new WaitForSeconds(0.5f);
        dot.SetActive(true);
        Controller.GotoNextPage();
    }
}
