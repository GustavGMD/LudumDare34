using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IncialScene : MonoBehaviour {

	public Button start;

	// Use this for initialization
	void Start () {
		start.onClick.AddListener (delegate {
			SceneManager.LoadScene("SelectLevel");
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
