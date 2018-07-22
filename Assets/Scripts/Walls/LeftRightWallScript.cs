using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightWallScript : MonoBehaviour {
    [SerializeField]
    private Controller _controller;
    private bool _isProcessed = false; 

    private void OnCollisionEnter(Collision collision) {
        if (_isProcessed == true)
            return;
        _isProcessed = true;
        _controller.GotoNextPage();
    }
}
