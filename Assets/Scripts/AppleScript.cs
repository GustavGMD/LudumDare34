using UnityEngine;
using System.Collections;
using System;

public class AppleScript : MonoBehaviour
{

    public event Action<float[]> onUpdateBand;

    public int numOfSamples = 8192; //Min: 64, Max: 8192

    public AudioSource aSource;

    public float[] freqData;
    public float[] band;
    //public float[] band1;
    //public float[] band2;

    //public GameObject[] g;

    void Awake()
    {
        freqData = new float[numOfSamples];

        int n = freqData.Length;

        // checks n is a power of 2 in 2's complement format
        if (!Mathf.IsPowerOfTwo(n))
        {
            Debug.LogError("freqData length " + n + " is not a power of 2!!! Min: 64, Max: 8192.");
            return;
        }

        int k = 0;
        for (int j = 0; j < freqData.Length; j++)
        {
            n = n / 2;
            if (n <= 0) break;
            k++;
        }
        //Debug.Log("k: " + k.ToString());

        band = new float[k + 1];
        //band1 = new float[k + 1];
        //band2 = new float[k + 1];
        //g = new GameObject[k + 1];

        /**/
        for (int i = 0; i < band.Length; i++)
        {
            band[i] = 0;
            //g[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //g[i].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.cyan);
            //g[i].transform.position = new Vector3(i, 0, 0) + transform.position;
            //g[i].transform.SetParent(transform);
        }
        /**/
        InvokeRepeating("Check", 0.0f, 1.0f / 60.0f); // update at 15 fps
    }

    private void Check()
    {
        aSource.GetSpectrumData(freqData, 0, FFTWindow.Rectangular);
        //aSource.GetSpectrumData()

        int k = 0;
        int crossover = 2;

        for (int i = 0; i < freqData.Length; i++)
        {
            float d = freqData[i];
            float b = band[k];

            // find the max as the peak value in that frequency band.
            band[k] = (d > b) ? d : b;

            if (i > (crossover - 3))
            {
                k++;
                crossover *= 2;   // frequency crossover point for each band.
                //Vector3 tmp = new Vector3(g[k].transform.position.x, band[k] * 32, g[k].transform.position.z);
                //g[k].transform.position = tmp;
                band[k] = 0;
            }
        }

        if (onUpdateBand != null) onUpdateBand(band);
    }

        /**
        private void check()
        {
            aSource.GetSpectrumData(freqData, 0, FFTWindow.Rectangular);

            int k = 0;
            int crossover = 2;

            for (int i = 0; i < freqData.Length; i++)
            {
                float d = freqData[i];
                float b = band1[k];

                // find the max as the peak value in that frequency band.
                band1[k] = (d > b) ? d : b;

                if (i > (crossover - 3))
                {
                    k++;
                    crossover *= 2;   // frequency crossover point for each band.
                    //Vector3 tmp = new Vector3(g[k].transform.position.x, band[k] * 32, g[k].transform.position.z);
                    //g[k].transform.position = tmp;
                    band1[k] = 0;
                }
            }

            aSource.GetSpectrumData(freqData, 1, FFTWindow.Rectangular);

            k = 0;
            crossover = 2;

            for (int i = 0; i < freqData.Length; i++)
            {
                float d = freqData[i];
                float b = band2[k];

                // find the max as the peak value in that frequency band.
                band2[k] = (d > b) ? d : b;

                if (i > (crossover - 3))
                {
                    k++;
                    crossover *= 2;   // frequency crossover point for each band.
                    //Vector3 tmp = new Vector3(g[k].transform.position.x, band[k] * 32, g[k].transform.position.z);
                    //g[k].transform.position = tmp;
                    band2[k] = 0;
                }
            }

            for (int i = 0; i < band.Length; i++)
            {
                band[i] = (band1[i] + band2[i])/2;
            }
        }
        /**/
    }

