using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviourHelper : MonoBehaviour {

    public Controller Controller { get; set; }

    public void ChangeColorAndGotoNextPage(DotBehavior dot, Color color) {
        StartCoroutine(DelayedChangeColor(dot, color));
    }

    public IEnumerator DelayedChangeColor(DotBehavior dot, Color color) {
        yield return new WaitForSeconds(1.5f);
        dot.Material.color = color;
        Controller.GotoNextPage();
    }

    public void ShowDot(GameObject dot) {
        StartCoroutine(DelayedShowDot(dot));
    }

    public IEnumerator DelayedShowDot(GameObject dot) {
        yield return new WaitForSeconds(1);
        dot.SetActive(true);
    }

    public void ShowDotAndGotoNextPage(GameObject dot) {
        StartCoroutine(DelayedShowDotAndGotoNextPage(dot));
    }

    public IEnumerator DelayedShowDotAndGotoNextPage(GameObject dot) {
        yield return new WaitForSeconds(1);
        dot.SetActive(true);
        Controller.GotoNextPage();
    }
}
