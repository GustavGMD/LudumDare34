using UnityEngine;
using System.Collections;

public class RenderQueue : MonoBehaviour {

	public int renderOrder;
	// Use this for initialization
	void Start () {
		Renderer[] renders = GetComponentsInChildren<Renderer> ();

		for (int i = 0; i < renders.Length; i++) {
			renders [i].material.renderQueue = renderOrder;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
