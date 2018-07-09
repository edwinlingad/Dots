using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public void OnStartAgain() {
        SceneManager.LoadScene(1);
    }

    public void OnExit() {
        Application.Quit();
    }
}
