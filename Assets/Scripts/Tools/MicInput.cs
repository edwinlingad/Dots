using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MicInput : MonoBehaviour {

    public float sensitivity = 100;
    public float loudness = 0;
    private AudioSource _audio;

    public string AudioInputDevice { get; private set; }

    private void Awake() {
        _audio = gameObject.GetComponent<AudioSource>();
    }

    void Start() {
        _audio.clip = Microphone.Start(null, true, 10, 44100);
        _audio.loop = true; // Set the AudioClip to loop
        _audio.mute = true; // Mute the sound, we don't want the player to hear it
        while (!(Microphone.GetPosition(AudioInputDevice) > 0)) { } // Wait until the recording has started
        _audio.Play(); // Play the audio source!
    }

    void Update() {
        loudness = GetAveragedVolume() * sensitivity;
    }

    float GetAveragedVolume() {
        float[] data = new float[256];
        float a = 0;
        _audio.GetOutputData(data, 0);
        foreach (float s in data) {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }
}
