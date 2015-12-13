using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public SoundProcessor soundProcessor;
    public PlantController plantController;

    public AudioSource gameSong;

    public float secondsToBeginSong = 3;

	public int score;

	public Queue<GameObject>[] filaRitmos;

	public GameObject ritmoModel;

	public GameObject[] area;

	public int comboCount = 0;

	public Vector3[] spawnPosition;

    public int scorePerfeito = 10;
	public float perfeito;

    public int scoreBom = 5;
	public float bom;

	public int countPerfeito;

	public int countBom;

	public int countErros;

    public int energia = 50;

	// Use this for initialization
	void Start () {
		//InvokeRepeating("GameObjectSpawn", 0.0f, 2.0f); // update at 15 fps
		countPerfeito = 0;
		countBom = 0;
		countErros = 0;

		filaRitmos = new Queue<GameObject>[2];
		filaRitmos[0] = new Queue<GameObject>();
		filaRitmos[1] = new Queue<GameObject>();

        soundProcessor.onSpawn += GameObjectSpawn;

        Invoke("StartSong", secondsToBeginSong);
	}

	void GameObjectSpawn(){
		
		int res = UnityEngine.Random.Range (0, 2);
		GameObject obj =(GameObject) Instantiate (ritmoModel, spawnPosition[res], Quaternion.identity);
		filaRitmos [res].Enqueue (obj);
	}
	
	// Update is called once per frame
	void Update () {

		/*
		for(int i = 0; i < Input.touchCount; i++)
		{
			Touch myTouch = Input.GetTouch(i);
			//Do something with the touches
			if (myTouch.position.x <= Screen.width / 2) {
				Destroy (filaRitmo[0]);
			}
		}
		*/
		if (Input.GetMouseButtonDown(0)) {
			int ind = 1;
			if (Input.mousePosition.x <= Screen.width / 2) { //Lado Esquerdo
				ind = 0;
			}
			if (filaRitmos[ind].Count > 0) {
				GameObject ok = filaRitmos[ind].Dequeue ();
				UpdateScore (ok, area[ind]);
			}
		}
		//Button Pause?

		//Lado Esquerdo


		//Lado Direito
	}

	void UpdateScore(GameObject obj, GameObject area){
        		
		if (Mathf.Abs (area.transform.position.y - obj.transform.position.y) < perfeito) {
			score += scorePerfeito;
            energia += scorePerfeito;
            if (energia > 100) energia = 100;
            plantController.UpdateEnergia(energia);
			comboCount++;
			countPerfeito++;
		} else if (Mathf.Abs (area.transform.position.y - obj.transform.position.y) < bom) {
			score += scoreBom;
            energia += scoreBom;
            if (energia > 100) energia = 100;
            plantController.UpdateEnergia(energia);
            comboCount++;
			countBom++;
		} else {
            energia -= scoreBom;
            plantController.UpdateEnergia(energia);
            if (energia <= 0)
            {
                //chama função de derrota
            }
            comboCount = 0;
			countErros++;
			//Fail
		}

        Destroy(obj);
    }

    void StartSong()
    {
        gameSong.Play();
    }

    public void ObjectCollidedWithEndLine(int index)
    {
        GameObject ok = filaRitmos[index].Dequeue();
        energia -= scoreBom;
        plantController.UpdateEnergia(energia);
        if (energia <= 0)
        {
            //chama função de derrota
        }
        comboCount = 0;
        countErros++;
        Destroy(ok);
    }
}
