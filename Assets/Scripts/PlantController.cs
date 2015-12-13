using UnityEngine;
using System.Collections;

public class PlantController : MonoBehaviour {

    public GameObject[] plantsBase;

    public void UpdateEnergia(int valor)
    {
        for (int i = 0; i < plantsBase.Length; i++)
        {
            plantsBase[i].GetComponent<Animator>().SetInteger("energia", valor);
        }
    }

    public void SetPlayer(int index)
    {
        for (int i = 0; i < plantsBase.Length; i++)
        {
            plantsBase[i].SetActive(i == index);
        }
    }
}
