using UnityEngine;
using System.Collections;

public class RitmoMovement : MonoBehaviour {

	public float step = 0.4f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position -= new Vector3(0, step * Time.deltaTime,0);
	}
}