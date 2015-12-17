using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour {

    //enum usado para salvar informações no "playerprefs"(permanencia de dados)
    //em C#, enum também guarda uma string igual ao nome do enumerador, além do int
    public enum DataType
    {
        HAS_PLAYER_DATA,
        LEVEL_UNLOCKED_
    }

	public Button[] levelButtons;

	public int totalLevels;
	public int level;

	public int plantSelected;

	public Sprite[] sprites;

	public Button[] selectPlant;

    public Button returnToInicial;

	public GameObject plant;
	// Use this for initialization
	void Start () {
        //confere se há dados salvos
        string __key = DataType.HAS_PLAYER_DATA.ToString();
        if (!PlayerPrefs.HasKey(__key))
        {
            PlayerPrefs.SetInt(__key, 1);

            SetLevelUnlocked(0, true);
            for (int i = 1; i < totalLevels; i++)
            {
                SetLevelUnlocked(i, false);
            }                    
        }

		plantSelected = 0;
		for (int i = 0; i < levelButtons.Length; i++) {
			int num = i;
			//levelButtons [i].GetComponentInChildren<Text> ().text = " "+(i+1);
            levelButtons [i].interactable = GetLevelUnlocked(i);
			levelButtons [i].onClick.AddListener (delegate 
            {
				level = num;
				transicao();
			});
		}

		for (int i = 0; i < selectPlant.Length; i++) {
			int nums = i;
			selectPlant [i].onClick.AddListener (delegate {
				changePlant (nums);
			});
		}

        returnToInicial.onClick.AddListener(delegate
        {
            Application.LoadLevel("Inicial");
        });

		changeSprite ();
        changePlant(0);

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
                if (GetLevelUnlocked(plantSelected - 1))
                {
                    plantSelected--;
                    changeSprite();
                }
			}
		} else {
			if (plantSelected != sprites.Length - 1) {
                if (GetLevelUnlocked(plantSelected + 1))
                {
                    plantSelected++;
                    changeSprite();
                }
                
            }
		}

        selectPlant[0].interactable = (plantSelected != 0);
        selectPlant[1].interactable = (plantSelected != sprites.Length - 1) && GetLevelUnlocked(plantSelected+1);
    }

	void changeSprite(){
		//Animation para mudar a sprite?
		plant.GetComponent<SpriteRenderer> ().sprite = sprites [plantSelected];
	}

	void transicao(){
		//Debug.Log ("Level: " + level);
		GlobalVars vars = GlobalVars.Instance;
		vars.levelAtual = level;
		vars.plantSelected = plantSelected;
        Application.LoadLevel("GameScene");
	}


    //PERMANENCIA DE DADOS  
    public static void SetLevelUnlocked(int levelIndex, bool value)
    {
        string __key = DataType.LEVEL_UNLOCKED_.ToString() + levelIndex.ToString("d2");
        PlayerPrefs.SetInt(__key, value ? 1 : 0);
    }

    public static bool GetLevelUnlocked(int levelIndex)
    {
        string __key = DataType.LEVEL_UNLOCKED_.ToString() + levelIndex.ToString("d2");
        if (PlayerPrefs.HasKey(__key))
            return PlayerPrefs.GetInt(__key) == 1;
        else
            return false;
    }

}
