using UnityEngine;
using System.Collections;

public class EndLine : MonoBehaviour {

    public GameManager gameManager;
    /// <summary>
    /// 0 = esquerda, 1 = direita
    /// </summary>
    public int lado;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D p_collision)
    {
        gameManager.ObjectCollidedWithEndLine(lado);
    }
}
