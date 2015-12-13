using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour {

	public Button[] levelButtons;

	public int totalLevels;
	public int level;
	// Use this for initialization
	void Start () {

		for (int i = 0; i < levelButtons.Length; i++) {
			int num = i;
			levelButtons [i].GetComponentInChildren<Text> ().text = " "+(i+1);
			levelButtons [i].onClick.AddListener (delegate {
				level = num;
				//
				transicao();
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

	void transicao(){
		//Debug.Log ("Level: " + level);
		//SceneManager.LoadScene ("level" + level.ToString ("d2"));
		//
	}

}
