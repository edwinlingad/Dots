using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotBehavior : MonoBehaviour {
    private Controller _controller;
    public Material Material { get; private set; }
    public int Id;

    private void Start() {
        _controller = GameObject.FindObjectOfType<Controller>();
        Material = GetComponent<Renderer>().material;
    }

    private void OnCollisionEnter(Collision collision) {
        _controller.OnPressed(this);
    }

    private void OnTriggerEnter(Collider other) {
        _controller.OnPressed(this);
    }

    private void OnMouseDown() {
        _controller.OnPressed(this);
        
    }
}
