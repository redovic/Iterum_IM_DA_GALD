﻿using UnityEngine;
using System.Collections;

public class HeartFFT : MonoBehaviour {

    HeartDeformer deformer;
    AudioSource audio;
    float[] spectrum = new float[64];

    void Start() {
        audio = GetComponent<AudioSource>();

        deformer = GetComponent<HeartDeformer>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (audio.isPlaying)
        //        audio.Pause();
        //    else
        //        audio.Play();
        //}

        if (audio != null) {
            audio.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
            deformer.ArrayOffests(spectrum);
        }

        //DrawLines(spectrum);
    }

    private void DrawLines(float[] spectrum)
    {
        int i = 1;
        while (i < spectrum.Length - 1)
        {
            Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.yellow);
            i++;
        }
    }

    private void PrintValues(float[] spectrum) {
        string s = "";
        for (int i = 0; i < spectrum.Length; i++) {
            s += i + ": " + spectrum[i] + " ";
        }
        print(s);
    }
}
