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
			labels [4] = "Sucess " + vars.rank;
		} else {
			labels [4] = "Fail";
		}

		values [0] = vars.countPerfeito;
		values [1] = vars.countBom;
		values [2] = vars.comboMax;
		values [3] = vars.countErros;

		for (int i = 0; i < labels.Length; i++) {
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
