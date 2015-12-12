using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public int score;

	public Queue<GameObject>[] filaRitmos;

	public GameObject ritmoModel;

	public GameObject[] area;

	public int comboCount = 0;

	public Vector3[] spawnPosition;

	public float perfeito;

	public float bom;

	public int countPerfeito;

	public int countBom;

	public int countErros;

	// Use this for initialization
	void Start () {
		InvokeRepeating("GameObjectSpawn", 0.0f, 2.0f); // update at 15 fps
		countPerfeito = 0;
		countBom = 0;
		countErros = 0;

		filaRitmos = new Queue<GameObject>[2];
		filaRitmos[0] = new Queue<GameObject>();
		filaRitmos[1] = new Queue<GameObject>();
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
				GameObject ok = (GameObject)filaRitmos[ind].Dequeue ();
				UpdateScore (ok, area[ind]);
				Destroy (ok);
			}
		}
		//Button Pause?

		//Lado Esquerdo


		//Lado Direito
	}

	void UpdateScore(GameObject obj, GameObject area){
		
		if (Mathf.Abs (area.transform.position.y - obj.transform.position.y) < perfeito) {
			score += 10;
			comboCount++;
			countPerfeito++;
		} else if (Mathf.Abs (area.transform.position.y - obj.transform.position.y) < bom) {
			score += 8;
			comboCount++;
			countBom++;
		} else {
			comboCount = 0;
			countErros++;
			//Fail
		}
		
	}
}
