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
			//labels [5].text = "Sucess";
			labels[6].text = vars.rank;
            labels[6].color = Color.yellow;
            levelManager.SetLevelUnlocked(GlobalVars.Instance.levelAtual+1, true);
		} else {
			//labels [5].text = "Fail";
			labels[6].text = "Fail";
            labels[6].color = Color.red;
        }

		values [0] = vars.countPerfeito;
		values [1] = vars.countBom;
		values [2] = vars.comboMax;
		values [3] = vars.countErros;
		int max = values [0] + values [1] + values [3];
		int acertos = values [0] + values [1];
		float hits = ((float)acertos / max) * 100;

		for (int i = 0; i < values.Length; i++) {
			labels[i].text = values[i].ToString();
		}
		labels[4].text = hits.ToString("##")+"%";

		back.onClick.AddListener (delegate {
			SceneManager.LoadScene ("SelectLevel");
		});
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
