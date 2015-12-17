using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class IncialScene : MonoBehaviour {

	public Button start;
    public Button credits;

	// Use this for initialization
	void Start () {
		start.onClick.AddListener (delegate {
			Application.LoadLevel("SelectLevel");
		});
        credits.onClick.AddListener(delegate {
            Application.LoadLevel("Credits");
        });
    }	
}
