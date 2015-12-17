using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class MusicaMenu : MonoBehaviour {

    bool paused = true;

    // Use this for initialization
    void Awake () {
        DontDestroyOnLoad(gameObject);
        MusicaMenu temp = FindObjectOfType<MusicaMenu>();
        if (temp != null)
        {
            Destroy(temp.gameObject);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Application.loadedLevelName == "GameScene")
        {
            if (!paused)
            {
                paused = true;
                GetComponent<AudioSource>().Stop();
            }
        }
        else
        {
            if (paused)
            {
                paused = false;
                GetComponent<AudioSource>().Play();
            }
        }
	}
}
