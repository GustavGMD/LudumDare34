using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SoundProcessor : MonoBehaviour {

    public event Action onSpawn;

    public GameObject ritmoModel;

    public float bandNormalizer = 100;
    public float[] lastBand;
    public float[] deltaBand;           //the variation for each band from one fram to another
    public float[] deltaDeltaBand;      //the variation of the variation from one fram to another

    public List<float> deltaPerUdate;
    public List<float> deltaDeltaPerUdate;

    public float currentDeltaSum = 0;       //soma de todos os deltas(variações) positivos
    public float ritmoThreshold = 20;       //quando a soma dos deltas chegar neste valor, cria um novo ritmo  
    public float deltaThreshold = 1;        //quando a soma da variação dos deltas passar deste valor, adiciona o valor do delta atual na soma dos deltas

    private AppleScript appleScript;

	// Use this for initialization
	void Start () {
        deltaPerUdate = new List<float>();
        deltaDeltaPerUdate = new List<float>();
        appleScript = GetComponent<AppleScript>();
        deltaBand = new float[appleScript.band.Length];
        deltaDeltaBand = new float[appleScript.band.Length];
        lastBand = new float[appleScript.band.Length];
        
        appleScript.onUpdateBand += UpdateDeltaBand;
	}

    public void UpdateDeltaBand(float[] p_newBand)
    {
        float __deltaSum = 0;
        float __deltaDeltaSum = 0;
        float __lastDelta = 0;
        //currentDeltaSum = 0;
        for (int i = 0; i < p_newBand.Length; i++)
        {
            __lastDelta = deltaBand[i];
            deltaBand[i] = (p_newBand[i]*bandNormalizer) - lastBand[i];
            lastBand[i] = p_newBand[i];
            deltaDeltaBand[i] = deltaBand[i] - __lastDelta;

            if (deltaDeltaBand[i] > deltaThreshold) currentDeltaSum += deltaBand[i];
            __deltaSum += deltaBand[i];
            __deltaDeltaSum += deltaDeltaBand[i];
        }

        deltaPerUdate.Add(__deltaSum);
        deltaDeltaPerUdate.Add(__deltaDeltaSum);

        if(currentDeltaSum >= ritmoThreshold)
        {            
            if (onSpawn != null) onSpawn();
            currentDeltaSum = 0;
            //currentDeltaSum -= ritmoThreshold;
            //SpawnRitmo();
        }

        //currentDeltaSum = 0;
    }

    /**
    public void SpawnRitmo()
    {
        Instantiate(ritmoModel, transform.position , Quaternion.identity);
    }
    /**/
}
