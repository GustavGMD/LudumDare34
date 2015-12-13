using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

	//Order
	/*public int perfeitos;
	public int bons;
	public int erros;
	public int maxcombo;
	*/
	public int[] values;

	public Text[] labels;

	public Button back;


	// Use this for initialization
	void Start () {
		GlobalVars vars = GlobalVars.Instance;

		if (vars.win) {
			labels [5].text = "Sucess";
			labels [6].text = vars.rank;
		} else {
			labels [5].text = "Fail";
			labels [6].text = " ";
		}

		values [0] = vars.countPerfeito;
		values [1] = vars.countBom;
		values [2] = vars.comboMax;
		values [3] = vars.countErros;
		int max = values [0] + values [1] + values [3];
		int acertos = values [0] + values [1];
		values [4] = (acertos / max) * 100;

		Debug.Log ("Acertos: "+values[4]);

		for (int i = 0; i < values.Length; i++) {
			labels[i].text = " " +values[i];
		}

		back.onClick.AddListener (delegate {
			SceneManager.LoadScene ("SelectLevel");
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
