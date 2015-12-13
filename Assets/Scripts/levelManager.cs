using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour {

	public Button[] levelButtons;

	public int totalLevels;
	public int level;

	public int plantSelected;

	public Sprite[] sprites;

	public Button[] selectPlant;

	public Sprite spritePlant;
	// Use this for initialization
	void Start () {
		plantSelected = 0;
		for (int i = 0; i < levelButtons.Length; i++) {
			int num = i;
			levelButtons [i].GetComponentInChildren<Text> ().text = " "+(i+1);
			levelButtons [i].onClick.AddListener (delegate {
				level = num;
				//
				transicao();
			});
		}
		for (int i = 0; i < selectPlant.Length; i++) {
			selectPlant [i].onClick.AddListener (delegate {
				changePlant (i);
			});
		}

		/*for (int i = 0; i < levels; i++) {
			Vector3 pos = new Vector3 (x+ (i%3)*stepx, y + (i/3)*stepy);
			GameObject obj = (GameObject) Instantiate(instance, pos, Quaternion.identity);
			levelButtons [i] = obj;
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void changePlant(int i){
		if (i == 0) { //Left
			if (plantSelected != 0) {
				plantSelected--;
				changeSprite ();
			}
		} else {
			if (plantSelected != sprites.Length - 1) {
				plantSelected++;
				changeSprite ();
			}
		}
	}

	void changeSprite(){
		//Animation para mudar a sprite?


	}

	void transicao(){
		//Debug.Log ("Level: " + level);
		GlobalVars vars = GlobalVars.Instance;
		vars.levelAtual = level;
		//SceneManager.LoadScene ("level" + level.ToString ("d2"));
		//
	}

}
