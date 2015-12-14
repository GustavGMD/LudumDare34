using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour {

	public void ChangeScene()
    {
        SceneManager.LoadScene("Inicial");
    }
}
