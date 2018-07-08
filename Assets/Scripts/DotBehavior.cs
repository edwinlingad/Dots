using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotBehavior : MonoBehaviour {
    private Vector3 _offset;
    private Controller _controller;
    private Vector3 _originalPosition;
    public Material Material { get; private set; }
    public int Id;

    private bool _isDragEnabled = false;
    public bool IsDragEnabled {
        get { return _isDragEnabled || Controller.IsGlobalDragEnabled; }
        set { _isDragEnabled = value; }
    }

    private void Start() {
        _originalPosition = new Vector3(transform.position.y, transform.position.y, transform.position.z);
        _controller = GameObject.FindObjectOfType<Controller>();
        Material = GetComponent<Renderer>().material;
    }

    private void OnMouseDown() {
        _controller.OnPressed(this);
    }

    private void OnMouseDrag() {
        if (IsDragEnabled == false)
            return;

        var curPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = curPosition;
    }

    private void Update() {
        var position = transform.position;
        position.z = 0;
        transform.position = position;
    }
    
}
