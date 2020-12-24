using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioAnalyzer : MonoBehaviour
{

    public AudioClip clip;

    private AudioSource audioSource;

    public AudioMixerGroup mic;

    public AudioMixerGroup master;

    public string device;
    
    public static int frameSize = 512;

    public static float[] spectrum;
    public static float[] waves;
    public static float[] bands;

    public static float amplitude = 0;

    public static float smoothAmp = 0;

    public float binWidth;

    public float sampleRate;
    // Start is called before the first frame update

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        spectrum = new float[frameSize];
        waves = new float[frameSize];
        bands = new float[(int)Mathf.Log(frameSize,2)];

        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = master;
        audioSource.Play();
    }

    void Start()
    {
        sampleRate = AudioSettings.outputSampleRate;
        binWidth = AudioSettings.outputSampleRate / 2 / frameSize;
        
    }

    void GetFrequencyBands()
    {
        for (int i = 0; i < bands.Length; i++)
        {
            int start = (int) Mathf.Pow(2, i) - 1;
            int width = (int) Mathf.Pow(2, i);
            int end = start + width;

            float avg = 0;
            for (int j = start; j < end; j++)
            {
                avg += spectrum[j] * (j + 1);
            }

            avg /= width;
            bands[i] = avg;
        }
    }

    void getAmplitude()
    {
        float total = 0;
        for (int i = 0; i < waves.Length; i++)
        {
            total += Mathf.Abs(waves[i]);
        }

        amplitude = total / waves.Length;
        smoothAmp = Mathf.Lerp(smoothAmp, amplitude, Time.deltaTime * 3);
        
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Blackman);
        audioSource.GetOutputData(waves, 0);
        getAmplitude();
        GetFrequencyBands();
        Debug.Log(spectrum);
    }
}
