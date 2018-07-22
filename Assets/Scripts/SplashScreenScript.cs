using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(GotoNextPage());
	}
	
	private IEnumerator GotoNextPage() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }


}
